namespace Eggstensions.SkyrimSE
{
	static public class TESProduceForm
	{
		public enum Seasons : System.UInt32
		{
			Spring =	0x0u,
			Summer =	0x1u,
			Fall =		0x2u,
			Winter =	0x3u
		}



		/// <param name="produceForm">TESProduceForm</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr produceForm)
		{
			if (produceForm == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(produceForm)); }

			return NetScriptFramework.Memory.ReadPointer(produceForm + 0x8);
		}

		/// <param name="produceForm">TESProduceForm</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr produceForm)
		{
			if (produceForm == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(produceForm)); }

			return NetScriptFramework.Memory.ReadPointer(produceForm + 0x10); // Ingredients can be any type of item
		}

		/// <param name="produceForm">TESProduceForm</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr produceForm)
		{
			if (produceForm == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(produceForm)); }

			return
			(
				NetScriptFramework.Memory.ReadInt8(produceForm + 0x18),
				NetScriptFramework.Memory.ReadInt8(produceForm + 0x18 + 0x1),
				NetScriptFramework.Memory.ReadInt8(produceForm + 0x18 + 0x2),
				NetScriptFramework.Memory.ReadInt8(produceForm + 0x18 + 0x3)
			);
		}

		/// <param name="produceForm">TESProduceForm</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr produceForm, System.IntPtr harvestSound)
		{
			if (produceForm == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(produceForm)); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(harvestSound)); }

			NetScriptFramework.Memory.WritePointer(produceForm + 0x18, harvestSound);
		}

		/// <param name="produceForm">TESProduceForm</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr produceForm, System.IntPtr ingredient)
		{
			if (produceForm == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(produceForm)); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ingredient)); }

			NetScriptFramework.Memory.WritePointer(produceForm + 0x10, ingredient);
		}
	}
}
