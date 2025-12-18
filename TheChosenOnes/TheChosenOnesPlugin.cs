using BepInEx;
using HarmonyLib;
using Obeliskial_Essentials;

namespace TheChosenOnes
{
    [BepInPlugin(Versioning.ModIdentifier, Versioning.ModName, Versioning.SemanticVersion)]
    public class TheChosenOnesPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            GameProvider.Plugin = this;
            GameProvider.Config = new GameConfig(Config);
            GameProvider.Log = Logger;
            Logger.LogInfo($"{Versioning.ModName} loaded");
            Essentials.RegisterMod(Versioning.ModName, Versioning.Author, Versioning.ModName, Versioning.SemanticVersion, Versioning.LastUpdateDate, Versioning.WebsiteUrl, null, Versioning.ModName, 100, null, "", true);
            new Harmony(Versioning.ModIdentifier).PatchAll();
        }
    }
}
