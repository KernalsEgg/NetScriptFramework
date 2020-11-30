namespace Eggstensions.Bethesda
{
	static public class TESFlora
	{
		/// <param name="flora">TESFlora</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("flora"); }
			if (!TESForm.HasFormType(flora, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("flora"); }

			return TESProduceForm.GetHarvestSound(flora + 0xC8);
		}

		/// <param name="flora">TESFlora</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("flora"); }
			if (!TESForm.HasFormType(flora, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("flora"); }

			return TESProduceForm.GetIngredient(flora + 0xC8);
		}

		/// <param name="flora">TESFlora</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr flora)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("flora"); }
			if (!TESForm.HasFormType(flora, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("flora"); }

			return TESProduceForm.GetIngredientChance(flora + 0xC8);
		}

		/// <param name="flora">TESFlora</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr flora, System.IntPtr harvestSound)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("flora"); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("harvestSound"); }
			if (!TESForm.HasFormType(flora, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("flora"); }

			TESProduceForm.SetHarvestSound(flora + 0xC8, harvestSound);
		}

		/// <param name="flora">TESFlora</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr flora, System.IntPtr ingredient)
		{
			if (flora == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("flora"); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("ingredient"); }
			if (!TESForm.HasFormType(flora, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("flora"); }

			TESProduceForm.SetHarvestSound(flora + 0xC8, ingredient);
		}
	}
}
