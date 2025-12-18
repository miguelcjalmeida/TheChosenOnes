using System.IO;
using System.Text.RegularExpressions;

namespace TheChosenOnes.Pack.Pipes
{
    public class PublishReadmePipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var sourcePath = Path.Combine(context.BaseDir, "../../..");
            var filePath = $"{sourcePath}/README.md";
            var content = File.ReadAllText(filePath);
            File.WriteAllText($"{context.PublishResourcesPath}/README.md", content);
        }
    }
}
