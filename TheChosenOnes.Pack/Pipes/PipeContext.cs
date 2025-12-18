namespace TheChosenOnes.Pack.Pipes
{
    public class PipeContext
    {
        public string PublishResourceName;
        public string PublishFinalZipPath;
        public string BaseDir;
        public string ModsDir;
        public string DistDir;
        public string PublishResourcesPath { get; }

        public PipeContext(string resourceName, string zipPath, string baseDir, string modsDir, string distDir, string modPath)
        {
            this.PublishResourceName = resourceName;
            this.PublishFinalZipPath = zipPath;
            this.BaseDir = baseDir;
            this.ModsDir = modsDir;
            this.DistDir = distDir;
            this.PublishResourcesPath = modPath;
        }
    }
}
