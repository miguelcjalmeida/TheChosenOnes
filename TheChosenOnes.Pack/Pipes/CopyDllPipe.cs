using System;
using System.IO;

namespace TheChosenOnes.Pack.Pipes
{
    public class CopyDllPipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var publishResourcesPath = context.PublishResourcesPath;
            string buildDir = Path.Combine(publishResourcesPath, "../..");
            string pluginsDir = Path.Combine(publishResourcesPath, "BepInEx/plugins");
            string dllName = Path.GetFileName(publishResourcesPath) + ".dll";
            string dllPath = $"{buildDir}/{dllName}";

            if (!File.Exists(dllPath))
                throw new Exception($"Missing build folder in mod: {dllPath}");

            Directory.CreateDirectory(pluginsDir);

            var dlls = Directory.GetFiles(buildDir, dllName);

            foreach (var dll in dlls)
            {
                string dest = Path.Combine(pluginsDir, dllName);
                File.Copy(dll, dest, overwrite: true);
                Console.WriteLine($"  - Copied {dllName}");
            }
        }
    }
}
