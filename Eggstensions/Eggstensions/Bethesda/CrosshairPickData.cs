namespace Eggstensions.Bethesda
{
	static public class CrosshairPickData
	{
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.CrosshairPickData.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="crosshairPickData">CrosshairPickData</param>
		/// <param name="bhkWorld">bhkWorld</param>
		/// <param name="position">NiPoint3</param>
		/// <param name="rotation">NiPoint3</param>
		static public System.IntPtr Pick(System.IntPtr crosshairPickData, System.IntPtr bhkWorld, System.IntPtr position, System.IntPtr rotation)
		{
			if (crosshairPickData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("crosshairPickData"); }
			if (bhkWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bhkWorld"); }
			// position
			// rotation

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.CrosshairPickData.Pick, crosshairPickData, bhkWorld, position, rotation);
		}

		/// <param name="crosshairPickData">CrosshairPickData</param>
		/// <param name="bhkWorld">bhkWorld</param>
		/// <returns></returns>
		static public System.IntPtr Pick(System.IntPtr crosshairPickData, System.IntPtr bhkWorld, (System.Single x, System.Single y, System.Single z) position, (System.Single x, System.Single y, System.Single z) rotation)
		{
			if (crosshairPickData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("crosshairPickData"); }
			if (bhkWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bhkWorld"); }
			// position
			// rotation

			using (var positionAllocation = new NiPoint3(new Math.Managed.Vector3(new System.Single[,] { { position.x, position.y, position.z } })))
			{
				using (var rotationAllocation = new NiPoint3(new Math.Managed.Vector3(new System.Single[,] { { rotation.x, rotation.y, rotation.z } })))
				{
					return NetScriptFramework.Memory.InvokeCdecl(VIDS.CrosshairPickData.Pick, crosshairPickData, bhkWorld, positionAllocation.Address, rotationAllocation.Address);
				}
			}
		}
	}
}
