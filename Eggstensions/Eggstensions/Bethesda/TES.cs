namespace Eggstensions.Bethesda
{
	static public class TES
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DB3E28 (VID501244)</summary>
		static public System.UInt32 GridsToLoad
		{
			get
			{
				var settingPointer = NetScriptFramework.Main.GameInfo.GetAddressOf(501244); // SettingT<INISettingCollection>
				if (settingPointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("settingPointer"); }

				return NetScriptFramework.Memory.ReadUInt32(settingPointer + 0x8);
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26B20 (VID516923)</summary>
		/// <returns>TES</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(516923);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
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
					foreach (var loadedCell in new GridCellArray(GridCellArray.GetInstance(tes)))
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
	}
}
