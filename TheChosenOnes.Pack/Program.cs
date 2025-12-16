using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChosenOnes.Pack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var baseDir = AppContext.BaseDirectory;
            var modsDir = Path.Combine(baseDir, "Mod");
            var distDir = Path.Combine(baseDir, "Dist");

            if (!Directory.Exists(modsDir))
            {
                Console.WriteLine("Mods directory not found.");
                return;
            }

            Directory.CreateDirectory(distDir);


            foreach (string modPath in Directory.GetDirectories(modsDir))
            {
                string modName = Path.GetFileName(modPath);
                string zipPath = Path.Combine(distDir, $"{modName}.zip");

                Console.WriteLine($"Packing {modName}...");

                if (!ValidateMod(modPath))
                {
                    Console.WriteLine($"❌ Skipped {modName} (invalid structure)");
                    continue;
                }

                CopyTheModDLL(modPath);

                if (File.Exists(zipPath))
                    File.Delete(zipPath);

                ZipDirectoryContents(modPath, zipPath);

                Console.WriteLine($"Created {zipPath}");
            }

        }

        private static bool ValidateMod(string modPath)
        {
            bool hasManifest = File.Exists(Path.Combine(modPath, "manifest.json"));
            bool hasReadme = File.Exists(Path.Combine(modPath, "README.md"));
            bool hasIcon = File.Exists(Path.Combine(modPath, "icon.png"));

            return hasManifest && hasReadme && hasIcon;
        }

        private static void CopyTheModDLL(string modPath)
        {
            string buildDir = Path.Combine(modPath, "../..");
            string pluginsDir = Path.Combine(modPath, "BepInEx/plugins");
            string dllName = Path.GetFileName(modPath) + ".dll";
            string dllPath = $"{buildDir}/{dllName}";

            if (!File.Exists(dllPath))
                throw new Exception($"Missing build folder in mod: {dllPath}");

            Directory.CreateDirectory(pluginsDir);

            var dlls = Directory.GetFiles(buildDir, dllName);

            foreach (var dll in dlls)
            {
                string dest = Path.Combine(pluginsDir, dllName);
                File.Copy(dll, dest, overwrite: true);
                Console.WriteLine($" - Copied {dllName}");
            }
        }

        private static void ZipDirectoryContents(string sourceDir, string zipPath)
        {
            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
                {
                    string entryName = GetRelativePath(sourceDir, file);
                    zip.CreateEntryFromFile(file, entryName, CompressionLevel.Optimal);
                }
            }
        }

        private static string GetRelativePath(string baseDir, string fullPath)
        {
            if (!baseDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                baseDir += Path.DirectorySeparatorChar;

            Uri baseUri = new Uri(baseDir);
            Uri fileUri = new Uri(fullPath);

            return Uri.UnescapeDataString(
                baseUri.MakeRelativeUri(fileUri)
                       .ToString()
                       .Replace('/', Path.DirectorySeparatorChar)
            );
        }
    }
}
