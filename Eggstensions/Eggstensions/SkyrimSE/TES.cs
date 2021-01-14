namespace Eggstensions.SkyrimSE
{
	static public class TES
	{
		/// <returns>TES</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.TES.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="tes">TES</param>
		/// <returns>TESObjectCELL, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentInteriorCell(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tes)); }

			return NetScriptFramework.Memory.ReadPointer(tes + 0xC0);
		}

		/// <param name="tes">TES</param>
		/// <returns>GridCellArray</returns>
		static public System.IntPtr GetGridCellArray(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tes)); }

			var gridCellArray = NetScriptFramework.Memory.ReadPointer(tes + 0x78);
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(gridCellArray)); }

			return gridCellArray;
		}

		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectCELL&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> GetLoadedCells(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(tes)); }

			var loadedCells = new System.Collections.Generic.HashSet<System.IntPtr>();

			var currentInteriorCell = TES.GetCurrentInteriorCell(tes);

			if (currentInteriorCell != System.IntPtr.Zero)
			{
				if (!TESObjectCELL.IsAttached(currentInteriorCell)) { throw new Eggceptions.SkyrimSE.DetachedCellException(nameof(currentInteriorCell)); }

				loadedCells.Add(currentInteriorCell);
			}
			else
			{
				foreach (var loadedCell in new GridCellArray(TES.GetGridCellArray(tes)))
				{
					if (!TESObjectCELL.IsAttached(loadedCell)) { throw new Eggceptions.SkyrimSE.DetachedCellException(nameof(loadedCell)); }

					loadedCells.Add(loadedCell);
				}
			}

			return loadedCells;
		}
	}
}
