using AcrossTheObelisk.Mod.Packer;
using System;
using System.IO;

namespace TheChosenOnes.Pack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseDir = AppContext.BaseDirectory;
            var sourceDir = Path.Combine(baseDir, "../../..");
            var packer = new Packer();

            packer.Pack(new PackerContext(
                otherResources: $"{baseDir}/Resources",
                distributionPath: $"{baseDir}/Dist",
                readmePath: $"{sourceDir}/README.md",
                changelogPath: $"{sourceDir}/CHANGELOG.md",
                modDllPath: $"{baseDir}/TheChosenOnes.dll",
                version: new PackVersion(
                    modIdentifier: Versioning.ModIdentifier,
                    modName: Versioning.ModName,
                    websiteUrl: Versioning.WebsiteUrl,
                    description: Versioning.Description,
                    author: Versioning.Author,
                    semanticVersion: Versioning.SemanticVersion,
                    lastUpdateDate: Versioning.LastUpdateDate,
                    dependencies: Versioning.Dependencies
                )
            ));
        }
    }
}
