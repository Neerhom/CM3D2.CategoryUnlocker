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
        //method that generates filed(public, static, literal, valutetype) with "name" and "integer" value in specified typedefinition
        private static void fieldgen2(string name, int integer, TypeDefinition typedef)
        {
            FieldDefinition newfield = new FieldDefinition($"{name}",
                            Mono.Cecil.FieldAttributes.Public | Mono.Cecil.FieldAttributes.Static |
                            Mono.Cecil.FieldAttributes.Literal | Mono.Cecil.FieldAttributes.HasDefault,
                            typedef)
            {
                Constant = integer
            };
            typedef.Fields.Add(newfield);
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
            fieldgen2("end", 74, tslotid);


            // add MPN
            TypeDefinition maid = assembly.MainModule.GetType("Maid");
            TypeDefinition mpn = assembly.MainModule.GetType("MPN");
            MethodDefinition CreateInitMaidPropList = maid.GetMethod("CreateInitMaidPropList");
            MethodDefinition maidpropext = catmanager.GetMethod("maidpropext");
            CreateInitMaidPropList.InjectWith(maidpropext, flags: InjectFlags.ModifyReturn);

            fieldgen(MPNarry, 88, mpn);


            //fix mpn update
            MethodDefinition AllProcProp = maid.GetMethod("AllProcProp");
            MethodDefinition AllProcExt = catmanager.GetMethod("AllProcExt");
            MethodDefinition AllProcSeqExt = catmanager.GetMethod("AllProcSeqExt");
            MethodDefinition AllProcPropSeq = maid.GetMethod("AllProcPropSeq");
            
            //extend loop within Maid.AllProcProp()
            int counter = 0;
          for (int instn = 0; instn < AllProcProp.Body.Instructions.Count; instn++)
          {
   
   
              if (AllProcProp.Body.Instructions[instn].OpCode == OpCodes.Add)
              { 
                  
                  {
                      
                      AllProcProp.InjectWith(AllProcExt, codeOffset: instn-2, flags: InjectFlags.PassInvokingInstance | InjectFlags.PassLocals , localsID: new[] { 2 });
                      break;
                  }
              }
              
   
          }
            //extend loop within Maid.AllProcPropSeq()
           
            
          for (int instn = 0; instn < AllProcPropSeq.Body.Instructions.Count; instn++)
          {
                           
              if (AllProcPropSeq.Body.Instructions[instn].OpCode == OpCodes.Br)
              {
                  counter+= 1;
                  
                       if (counter == 5)
                  {
    
                      AllProcPropSeq.InjectWith(AllProcSeqExt, codeOffset: instn, flags: InjectFlags.PassInvokingInstance | InjectFlags.PassLocals,
                          localsID: new[] { 0 });
                      break;
    
                  }
    
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

            // add body to EMenuPartsType
            fieldgen2("body", 66, EMenuPartsType);
        }
     }
}
