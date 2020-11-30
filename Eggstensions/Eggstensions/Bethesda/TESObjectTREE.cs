namespace Eggstensions.Bethesda
{
	static public class TESObjectTREE
	{
		/// <param name="tree">TESObjectTREE</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tree"); }
			if (!TESForm.HasFormType(tree, FormTypes.TESObjectTREE)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("tree"); }

			return TESProduceForm.GetHarvestSound(tree + 0x68);
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tree"); }
			if (!TESForm.HasFormType(tree, FormTypes.TESObjectTREE)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("tree"); }

			return TESProduceForm.GetIngredient(tree + 0x68);
		}

		/// <param name="tree">TESObjectTREE</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr tree)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tree"); }
			if (!TESForm.HasFormType(tree, FormTypes.TESObjectTREE)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("tree"); }

			return TESProduceForm.GetIngredientChance(tree + 0x68);
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr tree, System.IntPtr harvestSound)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tree"); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("harvestSound"); }
			if (!TESForm.HasFormType(tree, FormTypes.TESObjectTREE)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("tree"); }

			TESProduceForm.SetHarvestSound(tree + 0x68, harvestSound);
		}

		/// <param name="tree">TESObjectTREE</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr tree, System.IntPtr ingredient)
		{
			if (tree == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tree"); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("ingredient"); }
			if (!TESForm.HasFormType(tree, FormTypes.TESObjectTREE)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("tree"); }

			TESProduceForm.SetHarvestSound(tree + 0x68, ingredient);
		}
	}
}
