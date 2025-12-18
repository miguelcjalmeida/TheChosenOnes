using System;
using System.Collections.Generic;
using System.IO;
using TheChosenOnes.Pack.Pipes;

namespace TheChosenOnes.Pack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseDir = AppContext.BaseDirectory;
            var modsDir = Path.Combine(baseDir, "Resources");
            var distDir = Path.Combine(baseDir, "Dist");

            var pipes = new List<IPipe>();
            pipes.Add(new PublishManifestPipe());
            pipes.Add(new VersionReadmePipe());
            pipes.Add(new PublishReadmePipe());
            pipes.Add(new CopyDllPipe());
            pipes.Add(new PublishedResourcesValidationPipe());
            pipes.Add(new ZipPublishedResourcesPipe());

            if (!Directory.Exists(modsDir))
            {
                Console.WriteLine("- Mods directory not found.");
                return;
            }

            Directory.CreateDirectory(distDir);

            try
            {
                ProcessResources(baseDir, modsDir, distDir, pipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- FAILED DUE TO: {ex.Message}");
            }
        }

        private static void ProcessResources(string baseDir, string publishAllResourcesPath, string distDir, List<IPipe> pipes)
        {
            foreach (string publishResourcesPath in Directory.GetDirectories(publishAllResourcesPath))
            {
                var publishResourceName = Path.GetFileName(publishResourcesPath);
                var publishFinalZipPath = Path.Combine(distDir, $"{publishResourceName}.zip");
                var context = new PipeContext(publishResourceName, publishFinalZipPath, baseDir, publishAllResourcesPath, distDir, publishResourcesPath);

                Console.WriteLine($"Packing {publishResourceName}...");

                foreach (IPipe pipe in pipes)
                {
                    Console.WriteLine($"- Applying {pipe.GetType().Name}");
                    pipe.Apply(context);
                }
            }
        }
    }
}
