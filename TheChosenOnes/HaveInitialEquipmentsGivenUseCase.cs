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
            if (GameManager.Instance == null) return;
            if (AtOManager.Instance.currentMapNode != "sen_0")
            {
                GameProvider.Log.LogInfo("reset initial equips for next gameplay");
                equipsWereGiven = false;
                return;
            }

            if (equipsWereGiven) return;
            equipsWereGiven = true;

            ProvideDisclaimerForMultiplayer();
            AtOManager.Instance.SetObeliskLootReroll();
            AtOManager.Instance.DoLoot(GameProvider.Config.InitialLootId);
            GameProvider.Log.LogInfo("Opened loot rewards!");
        }

        private void ProvideDisclaimerForMultiplayer()
        {
            if (!GameManager.Instance.IsMultiplayer()) return;

            var lootCount = Globals.Instance.CardListByClass[Enums.CardClass.Item].Count;
            GameProvider.Log.LogWarning("For multiplayer games, you and other players must have same checksum.");
            GameProvider.Log.LogWarning("This mod only requires you and the others to have the same loots");
            GameProvider.Log.LogWarning($"You have {lootCount} loots available. Check with your friends whether they have the same quantity");
        }
    }
}
