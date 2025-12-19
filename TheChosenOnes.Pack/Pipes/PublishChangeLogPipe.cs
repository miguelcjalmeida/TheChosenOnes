using System.IO;

namespace TheChosenOnes.Pack.Pipes
{
    public class PublishChangeLogPipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var sourcePath = Path.Combine(context.BaseDir, "../../..");
            var filePath = $"{sourcePath}/CHANGELOG.md";
            var content = File.ReadAllText(filePath);
            File.WriteAllText($"{context.PublishResourcesPath}/CHANGELOG.md", content);
        }
    }
}
