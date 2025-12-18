using System.IO;
using System.Text.RegularExpressions;

namespace TheChosenOnes.Pack.Pipes
{
    public class VersionReadmePipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var sourcePath = Path.Combine(context.BaseDir, "../../..");
            var filePath = $"{sourcePath}/README.md";
            var content = File.ReadAllText(filePath);
            var regex = new Regex(@"v\d+\.\d+\.\d+");
            var newContent = regex.Replace(content, $"v{Versioning.SemanticVersion}");

            File.WriteAllText(filePath, newContent);
        }
    }
}
