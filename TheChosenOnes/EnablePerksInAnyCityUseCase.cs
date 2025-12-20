using System;
using System.Reflection;

namespace TheChosenOnes
{
    public class EnablePerksInAnyCityUseCase
    {
		public int originalCityTier = 0;

		public void PretendToBeInFirstCity(int originalCityTier)
		{
			if (!IsEditingPerkTreeFromCity()) return;
			this.originalCityTier = originalCityTier;
			GameProvider.Log.LogInfo("Pretending to be in first city");
			SetTownTier(0);
		}

		public void StopPretending()
		{
			GameProvider.Log.LogInfo("Stopped pretending to be in first city");
			SetTownTier(originalCityTier);
		}

		private bool IsEditingPerkTreeFromCity()
		{
			if (PerkTree.Instance == null) return false;
			if (AtOManager.Instance == null) return false;
			return AtOManager.Instance.CharInTown();
		}

		private void SetTownTier(int tier)
		{
			GameProvider.Log.LogInfo($"Setting town tier to {tier}");
			SetAttributeValue(AtOManager.Instance, "townTier", tier);
			AtOManager.Instance.gameHandicap = tier;
		}

		private void SetAttributeValue(object instance, string key, object value)
		{
			if (instance == null) return;

			Type type = instance.GetType();
			if (type == null) return;

			FieldInfo field = type.GetField(key, BindingFlags.NonPublic | BindingFlags.Instance);
			if (field == null) return;

			field.SetValue(instance, value);
		}


	}
}