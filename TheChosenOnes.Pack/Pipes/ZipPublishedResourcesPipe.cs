using System;
using System.IO;
using System.IO.Compression;

namespace TheChosenOnes.Pack.Pipes
{
    public class ZipPublishedResourcesPipe : IPipe
    {
        public void Apply(PipeContext context)
        {

            if (File.Exists(context.PublishFinalZipPath))
                File.Delete(context.PublishFinalZipPath);

            using (var zip = ZipFile.Open(context.PublishFinalZipPath, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(context.PublishResourcesPath, "*", SearchOption.AllDirectories))
                {
                    string entryName = GetRelativePath(context.PublishResourcesPath, file);
                    zip.CreateEntryFromFile(file, entryName, CompressionLevel.Optimal);
                }

                Console.WriteLine($"  - Created {context.PublishFinalZipPath}");
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
