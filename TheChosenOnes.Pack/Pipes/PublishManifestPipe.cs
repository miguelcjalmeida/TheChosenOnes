using Newtonsoft.Json;
using System.IO;

namespace TheChosenOnes.Pack.Pipes
{
    public class PublishManifestPipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            var manifest = new Manifest();
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };
            var content = JsonConvert.SerializeObject(manifest, Formatting.Indented, settings);
            File.WriteAllText($"{context.PublishResourcesPath}/manifest.json", content);
        }
    }
}
