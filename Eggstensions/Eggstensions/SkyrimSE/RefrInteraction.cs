﻿namespace Eggstensions.SkyrimSE
{
	static public class RefrInteraction
	{
		/// <param name="refrInteraction">RefrInteraction</param>
		static public BSPointerHandle.ReferenceFromHandle GetActor(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return new BSPointerHandle.ReferenceFromHandle(refrInteraction + 0x10);
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public System.UInt32 GetActorHandle(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return NetScriptFramework.Memory.ReadUInt32(refrInteraction + 0x10);
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public System.IntPtr GetActorHandleAddress(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return refrInteraction + 0x10;
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public System.Boolean GetSynced(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return NetScriptFramework.Memory.ReadUInt8(refrInteraction + 0x18) != 0;
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public BSPointerHandle.ReferenceFromHandle GetTarget(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return new BSPointerHandle.ReferenceFromHandle(refrInteraction + 0x14);
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public System.UInt32 GetTargetHandle(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return NetScriptFramework.Memory.ReadUInt32(refrInteraction + 0x14);
		}

		/// <param name="refrInteraction">RefrInteraction</param>
		static public System.IntPtr GetTargetHandleAddress(System.IntPtr refrInteraction)
		{
			if (refrInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(refrInteraction)); }

			return refrInteraction + 0x14;
		}
	}
}