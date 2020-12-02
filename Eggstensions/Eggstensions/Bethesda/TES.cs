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



		/// <param name="tes">TES</param>
		/// <returns>TESObjectCELL, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentInteriorCell(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tes"); }

			var currentInteriorCell = NetScriptFramework.Memory.ReadPointer(tes + 0xC0);
			if (currentInteriorCell == System.IntPtr.Zero) { return System.IntPtr.Zero; }
			if (!TESObjectCELL.IsAttached(currentInteriorCell)) { throw new Eggceptions.Bethesda.DetachedCellException("currentInteriorCell"); }

			return currentInteriorCell;
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

		/// <returns>System.Collections.Generic.IEnumerable&lt;TESObjectCELL&gt;</returns>
		static public System.Collections.Generic.IEnumerable<System.IntPtr> GetLoadedCells(System.IntPtr tes)
		{
			if (tes == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tes"); }

			var currentInteriorCell = TES.GetCurrentInteriorCell(tes);

			if (currentInteriorCell != System.IntPtr.Zero)
			{
				return _getCurrentInteriorCell();
			}
			else
			{
				return new GridCellArray(TES.GetGridCellArray(tes));
			}



			System.Collections.Generic.IEnumerable<System.IntPtr> _getCurrentInteriorCell()
			{
				yield return currentInteriorCell;
			}
		}
	}
}
