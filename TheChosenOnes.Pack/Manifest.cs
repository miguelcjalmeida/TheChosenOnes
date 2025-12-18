using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChosenOnes.Pack
{
    public class Manifest
    {
        public string name => Versioning.ModName;
        public string author => Versioning.Author;
        public string version_number => Versioning.SemanticVersion;
        public string website_url => Versioning.WebsiteUrl;
        public string description => Versioning.Description;
        public IList<string> dependencies => Versioning.Dependencies;
    }
}
