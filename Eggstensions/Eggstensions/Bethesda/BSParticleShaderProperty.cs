namespace Eggstensions.Bethesda
{
	static public class BSParticleShaderProperty
	{
		/// <param name="bsParticleShaderProperty">BSParticleShaderProperty</param>
		/// <returns>BSParticleShaderEmitter, System.IntPtr.Zero</returns>
		static public System.IntPtr GetParticleShaderEmitter(System.IntPtr bsParticleShaderProperty)
		{
			if (bsParticleShaderProperty == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderProperty"); }

			return NetScriptFramework.Memory.ReadPointer(bsParticleShaderProperty + 0x190);
		}
	}
}
