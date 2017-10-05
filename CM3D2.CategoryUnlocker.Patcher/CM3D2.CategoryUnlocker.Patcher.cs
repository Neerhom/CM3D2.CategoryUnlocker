using System.IO;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Inject;
using System.Linq;






namespace CM3D2.CategoryUnlocker.Patcher
{
   
    public static class CatPatcher
    {
        
        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };


        private const string HOOK_NAME = "CM3D2.CategoryUnlocker.Hook";

        //method that generates filed(public, static, literal, valutetype) with "name" and "integer" value in specified typedefinition
        private static FieldDefinition fieldgen(string name, int integer, TypeDefinition typedef)
        {
            FieldDefinition newfield = new FieldDefinition($"{name}",
                            Mono.Cecil.FieldAttributes.Public | Mono.Cecil.FieldAttributes.Static | 
                            Mono.Cecil.FieldAttributes.Literal | Mono.Cecil.FieldAttributes.HasDefault,
                            typedef)
            {
            Constant = integer};
            return newfield;
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
          
            tslotid.Fields.Add(fieldgen("nails", 58, tslotid));
            tslotid.Fields.Add(fieldgen("toenails", 59, tslotid));
            tslotid.Fields.Add(fieldgen("general1a", 60, tslotid));
            tslotid.Fields.Add(fieldgen("general1b", 61, tslotid));
            tslotid.Fields.Add(fieldgen("general2a", 62, tslotid));
            tslotid.Fields.Add(fieldgen("general2b", 63, tslotid));
            tslotid.Fields.Add(fieldgen("general3a", 64, tslotid));
            tslotid.Fields.Add(fieldgen("general3b", 65, tslotid));
            tslotid.Fields.Add(fieldgen("general4a", 66, tslotid));
            tslotid.Fields.Add(fieldgen("general4b", 67, tslotid));
            tslotid.Fields.Add(fieldgen("general5a", 68, tslotid));
            tslotid.Fields.Add(fieldgen("general5b", 69, tslotid));
            tslotid.Fields.Add(fieldgen("general6a", 70, tslotid));
            tslotid.Fields.Add(fieldgen("general6b", 71, tslotid));
            tslotid.Fields.Add(fieldgen("general7a", 72, tslotid));
            tslotid.Fields.Add(fieldgen("general7b", 73, tslotid));
            //add "end" field back. not sure if there is a point in messing with end field, but i can't be bothered checking
            tslotid.Fields.Add(fieldgen("end",74,tslotid));


            // add MPN
            TypeDefinition maid = assembly.MainModule.GetType("Maid");
            TypeDefinition mpn = assembly.MainModule.GetType("MPN");
            MethodDefinition CreateInitMaidPropList = maid.GetMethod("CreateInitMaidPropList");
            MethodDefinition maidpropext = catmanager.GetMethod("maidpropext");
            CreateInitMaidPropList.InjectWith(maidpropext, flags: InjectFlags.ModifyReturn);

            mpn.Fields.Add(fieldgen("folder_eye2", 88, mpn));
            mpn.Fields.Add(fieldgen("eye2", 89, mpn));
            mpn.Fields.Add(fieldgen("makeup1", 90, mpn));
            mpn.Fields.Add(fieldgen("makeup2", 91, mpn));
            mpn.Fields.Add(fieldgen("acctatoo2", 92, mpn));
            mpn.Fields.Add(fieldgen("acctatoo3", 93, mpn));
            mpn.Fields.Add(fieldgen("nails", 94, mpn));
            mpn.Fields.Add(fieldgen("toenails", 95, mpn));
            mpn.Fields.Add(fieldgen("skintoon", 96, mpn));
            mpn.Fields.Add(fieldgen("general1", 97, mpn));
            mpn.Fields.Add(fieldgen("general2", 98, mpn));
            mpn.Fields.Add(fieldgen("general3", 99, mpn));
            mpn.Fields.Add(fieldgen("general4", 100, mpn));
            mpn.Fields.Add(fieldgen("general5", 101, mpn));
            mpn.Fields.Add(fieldgen("general6", 102, mpn));
            mpn.Fields.Add(fieldgen("general7", 103 , mpn));

            // this is rather unnecessary, as it's possible to use existing MPN of diffferent type, but it's less headache this way.
            TypeDefinition EMenuPartsType = sceneEditInfo.NestedTypes.First(t => t.Name == "EMenuPartsType");

            EMenuPartsType.Fields.Add(fieldgen("folder_eye2", 50, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("eye2", 51, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("makeup1", 52, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("makeup2", 53, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("acctatoo2", 54, mpn));
            EMenuPartsType.Fields.Add(fieldgen("acctatoo3", 55, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("nails", 56, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("toenails", 57, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("skintoon", 58, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general1", 59, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general2", 60, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general3", 61, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general4", 62, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general5", 63, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general6", 64, EMenuPartsType));
            EMenuPartsType.Fields.Add(fieldgen("general7", 65, EMenuPartsType));

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
        }
     }
}
