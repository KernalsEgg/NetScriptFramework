namespace Eggstensions.SkyrimSE
{
	static public class BSParticleShaderCubeEmitter
	{
		/// <param name="particleShaderCubeEmitter">BSParticleShaderCubeEmitter</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetVelocity(System.IntPtr particleShaderCubeEmitter)
		{
			if (particleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(particleShaderCubeEmitter)); }

			return
			(
				BSParticleShaderCubeEmitter.GetVelocityX(particleShaderCubeEmitter),
				BSParticleShaderCubeEmitter.GetVelocityY(particleShaderCubeEmitter),
				BSParticleShaderCubeEmitter.GetVelocityZ(particleShaderCubeEmitter)
			);
		}

		/// <param name="particleShaderCubeEmitter">BSParticleShaderCubeEmitter</param>
		/// <returns>Units</returns>
		static public System.Single GetVelocityX(System.IntPtr particleShaderCubeEmitter)
		{
			if (particleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(particleShaderCubeEmitter)); }

			return NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF40) + NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF4C);
		}

		/// <param name="particleShaderCubeEmitter">BSParticleShaderCubeEmitter</param>
		/// <returns>Units</returns>
		static public System.Single GetVelocityY(System.IntPtr particleShaderCubeEmitter)
		{
			if (particleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(particleShaderCubeEmitter)); }

			return NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF44) + NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF50);
		}

		/// <param name="particleShaderCubeEmitter">BSParticleShaderCubeEmitter</param>
		/// <returns>Units</returns>
		static public System.Single GetVelocityZ(System.IntPtr particleShaderCubeEmitter)
		{
			if (particleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(particleShaderCubeEmitter)); }

			return NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF48) + NetScriptFramework.Memory.ReadFloat(particleShaderCubeEmitter + 0xF54);
		}
	}
}
