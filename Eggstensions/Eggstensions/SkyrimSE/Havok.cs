namespace Eggstensions.SkyrimSE
{
	static public class Havok
	{
		/// <param name="havokObject">HavokObject</param>
		static public CollisionLayers GetCollisionLayer(System.IntPtr havokObject)
		{
			if (havokObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokObject)); }

			return (CollisionLayers)(NetScriptFramework.Memory.ReadUInt32(havokObject + 0x2C) & 0x7F);
		}

		/// <param name="havokObject">HavokObject</param>
		/// <returns>NiObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNiObjectFromHavokObject(System.IntPtr havokObject)
		{
			if (havokObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokObject)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Havok.GetNiObjectFromHavokObject, havokObject);
		}
	}
}
