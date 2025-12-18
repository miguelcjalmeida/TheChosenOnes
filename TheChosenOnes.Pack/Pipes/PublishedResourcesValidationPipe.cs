using System;
using System.IO;

namespace TheChosenOnes.Pack.Pipes
{
    public class PublishedResourcesValidationPipe : IPipe
    {
        public void Apply(PipeContext context)
        {
            if (ValidateMod(context.PublishResourcesPath)) return;
            throw new ApplicationException("Some resource is missing");
        }

        private static bool ValidateMod(string modPath)
        {
            bool hasManifest = File.Exists(Path.Combine(modPath, "manifest.json"));
            bool hasReadme = File.Exists(Path.Combine(modPath, "README.md"));
            bool hasIcon = File.Exists(Path.Combine(modPath, "icon.png"));
            bool hasDll = File.Exists(Path.Combine(modPath, "BepInEx/plugins/TheChosenOnes.dll"));

            return hasManifest && hasReadme && hasIcon && hasDll;
        }
    }
}
