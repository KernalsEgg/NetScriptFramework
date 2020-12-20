namespace Eggstensions.Bethesda
{
	static public class NiTransform
	{
		/// <param name="niTransform">NiTransform</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			return
				(
					NiTransform.GetPositionX(niTransform),
					NiTransform.GetPositionY(niTransform),
					NiTransform.GetPositionZ(niTransform)
				);
		}
		
		/// <param name="niTransform"></param>
		/// <returns>Units</returns>
		static public System.Single GetPositionX(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x24);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionY(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x28);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionZ(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x2C);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Radians[,]</returns>
		static public System.Single[,] GetRotation(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			var rows = 3;
			var columns = 3;
			var rotation = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					rotation[row, column] = NetScriptFramework.Memory.ReadFloat(niTransform + 0x4 * (row + rows * column));
				}
			}

			return rotation;
		}

		/// <param name="niTransform">NiTransform</param>
		static public System.Single GetScale(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTransform"); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x30);
		}
	}
}
