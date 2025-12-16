using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TheChosenOnes
{
    public class HaveInitialEquipmentsGivenUseCase : IUseCase
    {
        private bool equipsWereGiven = false;

        public void DoIt()
        {
            if (!GameProvider.Config.IsModEnabled) return;
            if (MapManager.Instance == null) return;
            if (AtOManager.Instance == null) return;
            if (AtOManager.Instance.currentMapNode != "sen_0")
            {
                GameProvider.Log.LogInfo("reset initial equips for next gameplay");
                equipsWereGiven = false;
                return;
            }

            if (equipsWereGiven) return;
            equipsWereGiven = true;

            GameProvider.Log.LogInfo($"current node = {AtOManager.Instance.currentMapNode}");
            GameProvider.Log.LogInfo($"initial loot list = {GameProvider.Config.InitialLootId}");
            GameProvider.Log.LogInfo("offering initial loot");
            AtOManager.Instance.DoLoot(GameProvider.Config.InitialLootId);
        }
    }
}
