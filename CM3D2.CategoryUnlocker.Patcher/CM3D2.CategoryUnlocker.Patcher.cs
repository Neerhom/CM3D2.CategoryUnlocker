using System.IO;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Inject;


namespace CM3D2.CategoryUnlockerk.Patcher
{
    public static class CatPatcher
    {
        
     


        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };

        
        private const string HOOK_NAME = "CM3D2.CategoryUnlocker.Hook";
        
         
       
        public static void Patch(AssemblyDefinition assembly)
        {
           string hookloc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

           AssemblyDefinition hookDefinition = AssemblyLoader.LoadAssembly(Path.Combine(hookloc, $"{HOOK_NAME}.dll"));
            //add categories to the list
            TypeDefinition sceneEditInfo = assembly.MainModule.GetType("SceneEditInfo");

            TypeDefinition catmanager = hookDefinition.MainModule.GetType($"{HOOK_NAME}.catmanager");

           MethodDefinition loadCustom = catmanager.GetMethod("loadcustomcats");
            
            MethodDefinition SE_cctor = sceneEditInfo.GetMethod(".cctor");
            SE_cctor.InjectWith(loadCustom, -1);
            
            // add del menus to dictionaryy. mostly OCD thing.
            // this kinda redundant as same can be doen with addition comands in del menus themselves, but whatever
            TypeDefinition CM3 = assembly.MainModule.GetType("CM3");
            MethodDefinition CM3_cctor = CM3.GetMethod(".cctor");

            MethodDefinition delmenuadder = catmanager.GetMethod("delmenuadder");
            CM3_cctor.InjectWith(delmenuadder, -1);
       
        }


        















    } 
}
