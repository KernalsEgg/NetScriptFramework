namespace Eggstensions.SkyrimSE
{
	static public class TESObjectTREE
	{
		/// <param name="tree">TESObjectTREE</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }

			return TESProduceForm.GetHarvestSound(TESObjectTREE.GetProduceForm(tree));
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }

			return TESProduceForm.GetIngredient(TESObjectTREE.GetProduceForm(tree));
		}

		/// <param name="tree">TESObjectTREE</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }

			return TESProduceForm.GetIngredientChance(TESObjectTREE.GetProduceForm(tree));
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <returns>TESProduceForm</returns>
		static public System.IntPtr GetProduceForm(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }

			return tree + 0x68;
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr tree, System.IntPtr harvestSound)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(harvestSound)); }

			TESProduceForm.SetHarvestSound(TESObjectTREE.GetProduceForm(tree), harvestSound);
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr tree, System.IntPtr ingredient)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tree)); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ingredient)); }

			TESProduceForm.SetHarvestSound(TESObjectTREE.GetProduceForm(tree), ingredient);
		}
	}
}
