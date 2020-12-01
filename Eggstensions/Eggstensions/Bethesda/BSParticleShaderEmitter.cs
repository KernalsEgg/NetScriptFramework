namespace Eggstensions.Bethesda
{
	static public class BSParticleShaderEmitter
	{
		static public (System.Single x, System.Single y, System.Single z) GetVelocity(System.IntPtr bsParticleShaderEmitter)
		{
			if (bsParticleShaderEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderEmitter"); }

			return
				(
					BSParticleShaderEmitter.GetVelocityX(bsParticleShaderEmitter),
					BSParticleShaderEmitter.GetVelocityY(bsParticleShaderEmitter),
					BSParticleShaderEmitter.GetVelocityZ(bsParticleShaderEmitter)
				);
		}

		static public System.Single GetVelocityX(System.IntPtr bsParticleShaderEmitter)
		{
			if (bsParticleShaderEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderEmitter + 0xF40);
		}

		static public System.Single GetVelocityY(System.IntPtr bsParticleShaderEmitter)
		{
			if (bsParticleShaderEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderEmitter + 0xF44);
		}

		static public System.Single GetVelocityZ(System.IntPtr bsParticleShaderEmitter)
		{
			if (bsParticleShaderEmitter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsParticleShaderEmitter"); }

			return NetScriptFramework.Memory.ReadFloat(bsParticleShaderEmitter + 0xF54);
		}
	}
}
