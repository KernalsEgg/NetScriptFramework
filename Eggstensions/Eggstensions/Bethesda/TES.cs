namespace Eggstensions.Bethesda
{
	static public class TES
	{
		static public System.UInt32 GridsToLoad
		{
			get
			{
				return NetScriptFramework.Memory.ReadUInt32(VIDS.TES.GridsToLoad + 0x8); // SettingT<INISettingCollection>
			}
		}

		/// <returns>TES</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.TES.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}

		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectCELL&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> LoadedCells
		{
			get
			{
				var loadedCells = new System.Collections.Generic.HashSet<System.IntPtr>();

				var tes = TES.Instance;
				var currentInteriorCell = TES.GetCurrentInteriorCell(tes);

				if (currentInteriorCell != System.IntPtr.Zero)
				{
					if (TESObjectCELL.IsAttached(currentInteriorCell))
					{
						loadedCells.Add(currentInteriorCell);
					}
				}
				else
				{
					foreach (var loadedCell in new GridCellArray(TES.GetGridCellArray(tes)))
					{
						if (TESObjectCELL.IsAttached(loadedCell))
						{
							loadedCells.Add(loadedCell);
						}
					}
				}

				return loadedCells;
			}
		}



		/// <param name="tes">TES</param>
		/// <returns>TESObjectCELL, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentInteriorCell(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tes"); }

			return NetScriptFramework.Memory.ReadPointer(tes + 0xC0);
		}

		/// <param name="tes">TES</param>
		/// <returns>GridCellArray</returns>
		static public System.IntPtr GetGridCellArray(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tes"); }

			var gridCellArray = NetScriptFramework.Memory.ReadPointer(tes + 0x78);
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.NullException("gridCellArray"); }

			return gridCellArray;
		}
	}
}
