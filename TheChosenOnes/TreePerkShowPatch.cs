using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace TheChosenOnes
{
	[HarmonyPatch(typeof(PerkTree), "Show")]
	public class PerkTreeShowPatch
	{
		public static EnablePerksInAnyCityUseCase useCase = new EnablePerksInAnyCityUseCase();

		public static void Prefix()
		{
			var townTierBeforePretending = AtOManager.Instance.GetTownTier();
			useCase.PretendToBeInFirstCity(townTierBeforePretending);
		}
	}

	[HarmonyPatch(typeof(PerkTree), "HideAction")]
	public class PerkTreeHideActionPatch
	{
		public static void Postfix()
		{
			PerkTreeShowPatch.useCase.StopPretending();
		}
	}
}
