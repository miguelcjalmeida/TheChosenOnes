using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChosenOnes
{
    [HarmonyPatch(typeof(MapManager), "Start")]
    public static class MapManagerStartPatch
    {
        private static IUseCase useCase = new HaveInitialEquipmentsGivenUseCase();

        public static void Postfix()
        {
            useCase.DoIt();
			PerkTree.Instance.buttonConfirm.gameObject.SetActive(true);
		}
    }
}
