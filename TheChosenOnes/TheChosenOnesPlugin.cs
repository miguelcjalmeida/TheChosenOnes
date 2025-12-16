using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Obeliskial_Essentials;
using UnityEngine;

namespace TheChosenOnes
{
    [BepInPlugin("scotilen.thechosenones", "The Chosen Ones", "1.0.0")]
    public class TheChosenOnesPlugin : BaseUnityPlugin
    {
        private static bool legendaryGiven = false;
        public static ManualLogSource Log = null;

        private void Awake()
        {
            GameProvider.Config = new GameConfig(Config);
            GameProvider.Log = Logger;
            Logger.LogInfo("The Chosen Ones loaded");
            Essentials.RegisterMod("The Chosen Ones", "Scotilen", "The Chosen Ones", "1.0.0", 20251216, "https://github.com/miguelcjalmeida/TheChosenOnes", null, "The Chosen Ones", 100, null, "", true);
            new Harmony("scotilen.thechosenones").PatchAll();
        }
    }
}
