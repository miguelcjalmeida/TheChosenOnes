using BepInEx.Configuration;

namespace TheChosenOnes
{
    public class GameConfig
    {
        public const string DefaultLootId = "thechosenshop";

        public bool IsModEnabled => EnabledEntry?.Value ?? true;

        public string InitialLootId => InitialLootIdEntry?.Value ?? DefaultLootId;

        public GameConfig(ConfigEntry<string> initialLootIdEntry, ConfigEntry<bool> enabledEntry)
        {
            InitialLootIdEntry = initialLootIdEntry;
            EnabledEntry = enabledEntry;
        }

        public GameConfig(ConfigFile config)
        {
            EnabledEntry = config.Bind(
                "General",
                "EnableMod",
                true,
                "Enable or disable the mod"
            );


            InitialLootIdEntry = config.Bind(
                "General", 
                "InitialLootIdx", 
                DefaultLootId, 
                "The loot list ID to have displayed once the game starts"
            );
        }

        private ConfigEntry<string> InitialLootIdEntry { get; set; } = null;

        private ConfigEntry<bool> EnabledEntry { get; set; } = null;
    }
}
