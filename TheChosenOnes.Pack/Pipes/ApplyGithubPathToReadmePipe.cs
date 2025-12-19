using System.IO;
using System.Text.RegularExpressions;

namespace TheChosenOnes.Pack.Pipes
{
    public class ApplyGithubPathToReadmePipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var githubBasePath = $"{Versioning.WebsiteUrl}/refs/heads/main";
            var filePath = $"{context.PublishResourcesPath}/README.md";
            var content = File.ReadAllText(filePath);
            var regex = new Regex(@"(?<begin>\!\[[^[]+\]\()(?<basepath>\.)(?<url>.*)(?<end>\))", RegexOptions.IgnoreCase);
            var newContent = regex.Replace(content, $@"${{begin}}{githubBasePath}${{url}}${{end}}");

            File.WriteAllText(filePath, newContent);
        }
    }
}
