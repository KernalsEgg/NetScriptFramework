namespace Eggstensions.SkyrimSE
{
	static public class TESFlora
	{
		/// <param name="flora">TESFlora</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }

			return TESProduceForm.GetHarvestSound(TESFlora.GetProduceForm(flora));
		}

		/// <param name="flora">TESFlora</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }

			return TESProduceForm.GetIngredient(TESFlora.GetProduceForm(flora));
		}

		/// <param name="flora">TESFlora</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }

			return TESProduceForm.GetIngredientChance(TESFlora.GetProduceForm(flora));
		}

		/// <param name="tree">TESFlora</param>
		/// <returns>TESProduceForm</returns>
		static public System.IntPtr GetProduceForm(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }

			return flora + 0xC8;
		}

		/// <param name="flora">TESFlora</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr flora, System.IntPtr harvestSound)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(harvestSound)); }

			TESProduceForm.SetHarvestSound(TESFlora.GetProduceForm(flora), harvestSound);
		}

		/// <param name="flora">TESFlora</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr flora, System.IntPtr ingredient)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(flora)); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ingredient)); }

			TESProduceForm.SetHarvestSound(TESFlora.GetProduceForm(flora), ingredient);
		}
	}
}
