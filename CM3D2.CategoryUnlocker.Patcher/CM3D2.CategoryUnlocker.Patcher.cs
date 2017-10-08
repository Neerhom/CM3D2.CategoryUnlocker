using System.IO;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Inject;
using System.Linq;
using Mono.Cecil.Cil;







namespace CM3D2.CategoryUnlocker.Patcher
{

    public static class CatPatcher
    {

        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };


        private const string HOOK_NAME = "CM3D2.CategoryUnlocker.Hook";

        // array of filleds that are to be appended to enum MPN
        public static readonly string[] MPNarry = new string[]
            {
            "folder_eye2",
            "eye2",
            "makeup1",
            "makeup2",
            "acctatoo2",
            "acctatoo3",
            "nails",
            "toenails",
            "skintoon",
            "general1",
            "general2",
            "general3",
            "general4",
            "general5",
            "general6",
            "general7"

            };
        // array of filleds that are to be appended to enum SlotID 
        public static readonly string[] SlotID = new string[]
            {
            "nails",
            "toenails",
            "general1a",
            "general1b",
            "general2a",
            "general2b",
            "general3a",
            "general3b",
            "general4a",
            "general4b",
            "general5a",
            "general5b",
            "general6a",
            "general6b",
            "general7a",
            "general7b"

            };


        // method for injecting MPN's to Maid.AllProcProp and Maid.AllPropcPropSeq
       
        public static void allprocext (int pos, int mpnN, MethodDefinition method, MethodReference getprop, FieldReference fieldref)
        {
        
                        method.Body.Instructions.Insert(pos, Instruction.Create(OpCodes.Call, getprop));
                        method.Body.Instructions.Insert(pos, Instruction.Create(OpCodes.Ldc_I4, mpnN));
                        method.Body.Instructions.Insert(pos, Instruction.Create(OpCodes.Ldarg_0));
                        method.Body.Instructions.Insert(pos, Instruction.Create(OpCodes.Stfld, fieldref));
                        method.Body.Instructions.Insert(pos, Instruction.Create(OpCodes.Ldc_I4_1));
            
        }

        

        //method that generates filed(public, static, literal, valutetype)
        // with "name" starting at "start" in specified typedefinition
        private static void fieldgen (string[] fieldnames, int start, TypeDefinition typedef)
            {
            for (int i = 0; i < fieldnames.Length; i++)
            {
                
                FieldDefinition newfield = new FieldDefinition(fieldnames[i],
                            Mono.Cecil.FieldAttributes.Public | Mono.Cecil.FieldAttributes.Static |
                            Mono.Cecil.FieldAttributes.Literal | Mono.Cecil.FieldAttributes.HasDefault,
                            typedef)
                {
                    Constant = start+i
                };
                typedef.Fields.Add(newfield);
               


            }
        }

        public static void Patch(AssemblyDefinition assembly)
        {
            string hookloc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //load hook

            AssemblyDefinition hookDefinition = AssemblyLoader.LoadAssembly(Path.Combine(hookloc, $"{HOOK_NAME}.dll"));
            TypeDefinition catmanager = hookDefinition.MainModule.GetType($"{HOOK_NAME}.catmanager");
            // add model slots         

            TypeDefinition tbody = assembly.MainModule.GetType("TBody");
            TypeDefinition tslotid = tbody.NestedTypes.First(t => t.Name == "SlotID");

            //remove IsInitOnly attribute from m_strDefSlotName
            FieldDefinition defslot = tbody.GetField("m_strDefSlotName");
            defslot.IsInitOnly = false;


            // extend m_strDefSlotName

            MethodDefinition slotext = catmanager.GetMethod("slotext");
            MethodDefinition TbodyInit = tbody.GetMethod("Init");
            TbodyInit.InjectWith(slotext);


            //remove "end" field
            tslotid.Fields.RemoveAt(59);

            fieldgen(SlotID, 58, tslotid);
            //add "end" field back. not sure if there is a point in messing with end field, but i can't be bothered checking
            tslotid.Fields.Add(fieldgen("end", 74, tslotid));


            // add MPN
            TypeDefinition maid = assembly.MainModule.GetType("Maid");
            TypeDefinition mpn = assembly.MainModule.GetType("MPN");
            MethodDefinition CreateInitMaidPropList = maid.GetMethod("CreateInitMaidPropList");
            MethodDefinition maidpropext = catmanager.GetMethod("maidpropext");
            CreateInitMaidPropList.InjectWith(maidpropext, flags: InjectFlags.ModifyReturn);

            fieldgen(MPNarry, 88, mpn);


            //fix mpn update
            MethodDefinition AllProcProp = maid.GetMethod("AllProcProp");
            MethodDefinition getprop = maid.GetMethod("GetProp", "MPN");
            MethodReference getpropref = maid.Module.ImportReference(getprop);

            TypeDefinition maidprop = assembly.MainModule.GetType("MaidProp");
            FieldDefinition boDut = maidprop.GetField("boDut");
            FieldReference boDutref = maidprop.Module.ImportReference(boDut);

            //extend loop within Maid.AllProcProp()

            for (int instn = 0; instn < AllProcProp.Body.Instructions.Count<Instruction>(); instn++)
            {
                // 37 and 36 are NON first  MPN integers in else if conditions of for loop
                if (AllProcProp.Body.Instructions[instn].OpCode == OpCodes.Ldc_I4_S &&
                  (sbyte?)(AllProcProp.Body.Instructions[instn].Operand) == 37)
                {
                    int pos = instn +2;
                    allprocext(pos, 89, AllProcProp, getpropref, boDutref);
                                                            
                }
                 if (AllProcProp.Body.Instructions[instn].OpCode == OpCodes.Ldc_I4_S &&
                   (sbyte?)AllProcProp.Body.Instructions[instn].Operand == 36)
                {
                    int pos = instn + 2;
                    allprocext(pos, 93, AllProcProp, getpropref, boDutref);
                    allprocext(pos, 92, AllProcProp, getpropref, boDutref);
                    allprocext(pos, 91, AllProcProp, getpropref, boDutref);
                    allprocext(pos, 90, AllProcProp, getpropref, boDutref);
                    break;
                }
            }



            //extend loop within Maid.AllProcPropSeq()
            MethodDefinition AllProcPropSeq = maid.GetMethod("AllProcPropSeq");
            for (int instn = 0; instn < AllProcPropSeq.Body.Instructions.Count<Instruction>(); instn++)
            {
                // 37 and 36 are NON first  MPN integers in else if conditions of for loop
                if (AllProcPropSeq.Body.Instructions[instn].OpCode == OpCodes.Ldc_I4_S &&
                   (sbyte?)(AllProcPropSeq.Body.Instructions[instn].Operand) == 37)
                {
                    int pos = instn + 2;
                    allprocext(pos, 89, AllProcPropSeq, getpropref, boDutref);

                }
                if (AllProcPropSeq.Body.Instructions[instn].OpCode == OpCodes.Ldc_I4_S &&
                   (sbyte?)(AllProcPropSeq.Body.Instructions[instn].Operand) == 36)
                {
                    int pos = instn + 2;
                    allprocext(pos, 93, AllProcPropSeq, getpropref, boDutref);
                    allprocext(pos, 92, AllProcPropSeq, getpropref, boDutref);
                    allprocext(pos, 91, AllProcPropSeq, getpropref, boDutref);
                    allprocext(pos, 90, AllProcPropSeq, getpropref, boDutref);
                    break;
                }
            }
            
          

            // expand PresetSetp reads

            //target definition
            TypeDefinition charactermgr = assembly.MainModule.GetType("CharacterMgr");
            MethodDefinition setpreset = charactermgr.GetMethod("PresetSet");
            // inject method definition
            MethodDefinition ExtSet = catmanager.GetMethod("ExtSet");

            setpreset.InjectWith(ExtSet, flags: InjectFlags.PassParametersVal);

            // add del menus to dictionaryy. mostly OCD thing.
            // this kinda redundant as same can be doen with addition comands in del menus themselves, but whatever
            TypeDefinition CM3 = assembly.MainModule.GetType("CM3");
            MethodDefinition CM3_cctor = CM3.GetMethod(".cctor");

            MethodDefinition delmenuadder = catmanager.GetMethod("delmenuadder");
            CM3_cctor.InjectWith(delmenuadder, -1);
            
            
            //add categories to the list
            TypeDefinition sceneEditInfo = assembly.MainModule.GetType("SceneEditInfo");
           
            MethodDefinition loadCustom = catmanager.GetMethod("loadcustomcats");

            MethodDefinition SE_cctor = sceneEditInfo.GetMethod(".cctor");
            SE_cctor.InjectWith(loadCustom, -1);
            // extend EMenuPartsType
            // this is rather unnecessary, as it's possible to use existing MPN of diffferent type, but it's less headache this way.
            TypeDefinition EMenuPartsType = sceneEditInfo.NestedTypes.First(t => t.Name == "EMenuPartsType");
            fieldgen(MPNarry,50, EMenuPartsType );
        }
     }
}
