namespace Eggstensions.Bethesda
{
	public enum Season : System.UInt32
	{
		Spring =	0x0u,
		Summer =	0x1u,
		Fall =		0x2u,
		Winter =	0x3u
	}
	


	static public class TESProduceForm
	{
		/// <param name="produce">TESProduceForm</param>
		/// <returns>BGSSoundDescriptorForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHarvestSound(System.IntPtr produce)
		{
			if (produce == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("produce"); }

			return NetScriptFramework.Memory.ReadPointer(produce + 0x8);
		}
		
		/// <param name="produce">TESProduceForm</param>
		/// <returns>TESBoundObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetIngredient(System.IntPtr produce)
		{
			if (produce == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("produce"); }

			return NetScriptFramework.Memory.ReadPointer(produce + 0x10); // Ingredients can be any type of item
		}

		/// <param name="produce">TESProduceForm</param>
		static public (System.SByte spring, System.SByte summer, System.SByte fall, System.SByte winter) GetIngredientChance(System.IntPtr produce)
		{
			if (produce == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("produce"); }

			return
			(
				NetScriptFramework.Memory.ReadInt8(produce + 0x18),
				NetScriptFramework.Memory.ReadInt8(produce + 0x18 + 0x1),
				NetScriptFramework.Memory.ReadInt8(produce + 0x18 + 0x2),
				NetScriptFramework.Memory.ReadInt8(produce + 0x18 + 0x3)
			);
		}

		/// <param name="produce">TESProduceForm</param>
		/// <param name="harvestSound">BGSSoundDescriptorForm</param>
		static public void SetHarvestSound(System.IntPtr produce, System.IntPtr harvestSound)
		{
			if (produce == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("produce"); }
			if (harvestSound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("harvestSound"); }

			NetScriptFramework.Memory.WritePointer(produce + 0x18, harvestSound);
		}

		/// <param name="produce">TESProduceForm</param>
		/// <param name="ingredient">TESBoundObject</param>
		static public void SetIngredient(System.IntPtr produce, System.IntPtr ingredient)
		{
			if (produce == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("produce"); }
			if (ingredient == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("ingredient"); }

			NetScriptFramework.Memory.WritePointer(produce + 0x10, ingredient);
		}
	}
}
