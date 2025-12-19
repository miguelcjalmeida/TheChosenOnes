using System.Collections.Generic;

namespace TheChosenOnes
{
    public class Versioning
    {
        public const string ModIdentifier = "scotilen.thechosenones";
        public const string ModName = "TheChosenOnes";
        public const string WebsiteUrl = "https://github.com/miguelcjalmeida/TheChosenOnes";
        public const string Description = "Have your heroes starting the game with an unique equipment to show how legendary they are.";
        public const string Author = "Scotilen";
        public const string SemanticVersion = "1.0.12";
        public const int LastUpdateDate = 20251219;
        public static IList<string> Dependencies = DetermineDependencies();

        private static IList<string> DetermineDependencies()
        {
            var dependencies = new List<string>();
            dependencies.Add("BepInEx-BepInExPack_AcrossTheObelisk-5.4.23");
            dependencies.Add("meds-Obeliskial_Essentials-1.6.0");
            dependencies.Add("meds-Obeliskial_Content-1.7.0");
            return dependencies;
        }
    }
}
