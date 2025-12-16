using BepInEx.Configuration;
using BepInEx.Logging;

namespace TheChosenOnes
{
    public static class GameProvider
    {
        public static ManualLogSource Log { get; set; } = null;
        public static GameConfig Config { get; set; } = null;
    }
}
