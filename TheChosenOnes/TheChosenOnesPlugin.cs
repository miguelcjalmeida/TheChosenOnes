using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Obeliskial_Essentials;
using UnityEngine;

namespace TheChosenOnes
{
    [BepInPlugin("scotilen.thechosenones", "TheChosenOnes", "1.0.1")]
    public class TheChosenOnesPlugin : BaseUnityPlugin
    {
        private static bool legendaryGiven = false;
        public static ManualLogSource Log = null;

        private void Awake()
        {
            GameProvider.Plugin = this;
            GameProvider.Config = new GameConfig(Config);
            GameProvider.Log = Logger;
            Logger.LogInfo("TheChosenOnes loaded");
            Essentials.RegisterMod("TheChosenOnes", "Scotilen", "TheChosenOnes", "1.0.1", 20251216, "https://github.com/miguelcjalmeida/TheChosenOnes", null, "TheChosenOnes", 100, null, "", true);
            new Harmony("scotilen.thechosenones").PatchAll();
        }
    }
}
