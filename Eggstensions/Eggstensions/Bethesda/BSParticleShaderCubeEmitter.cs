namespace Eggstensions.Bethesda
{
	static public class BSParticleShaderCubeEmitter
	{
		static public (System.Single x, System.Single y, System.Single z) GetVelocity(System.IntPtr bsParticleShaderCubeEmitter)
		{
			if (bsParticleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderCubeEmitter"); }

			return
				(
					BSParticleShaderCubeEmitter.GetVelocityX(bsParticleShaderCubeEmitter),
					BSParticleShaderCubeEmitter.GetVelocityY(bsParticleShaderCubeEmitter),
					BSParticleShaderCubeEmitter.GetVelocityZ(bsParticleShaderCubeEmitter)
				);
		}

		static public System.Single GetVelocityX(System.IntPtr bsParticleShaderCubeEmitter)
		{
			if (bsParticleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderCubeEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderCubeEmitter + 0xF40);
		}

		static public System.Single GetVelocityY(System.IntPtr bsParticleShaderCubeEmitter)
		{
			if (bsParticleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderCubeEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderCubeEmitter + 0xF44);
		}

		static public System.Single GetVelocityZ(System.IntPtr bsParticleShaderCubeEmitter)
		{
			if (bsParticleShaderCubeEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderCubeEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderCubeEmitter + 0xF54);
		}
	}
}
