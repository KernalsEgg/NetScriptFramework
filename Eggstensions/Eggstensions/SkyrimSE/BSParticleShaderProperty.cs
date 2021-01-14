namespace Eggstensions.SkyrimSE
{
	static public class BSParticleShaderProperty
	{
		/// <param name="particleShaderProperty">BSParticleShaderProperty</param>
		/// <returns>BSParticleShaderEmitter, System.IntPtr.Zero</returns>
		static public System.IntPtr GetParticleShaderEmitter(System.IntPtr particleShaderProperty)
		{
			if (particleShaderProperty == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(particleShaderProperty)); }

			return NetScriptFramework.Memory.ReadPointer(particleShaderProperty + 0x190);
		}
	}
}
