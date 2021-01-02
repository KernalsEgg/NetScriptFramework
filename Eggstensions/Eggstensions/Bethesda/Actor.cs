using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class Actor
	{
		static public System.UInt32 GetCollisionFilter(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				allocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetCollisionFilter, actor, allocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(allocation.Address);
			}
		}

		static public System.Single GetEyeLevel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdeclF(VIDS.Actor.GetEyeLevel, actor);
		}
		
		/// <param name="actor">Actor</param>
		static public System.Single GetLastUpdate(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.ReadFloat(actor + 0x258);
		}

		/// <param name = "actor">Actor</param>
		/// <returns>AIProcess</returns>
		static public System.IntPtr GetProcess(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var process = NetScriptFramework.Memory.ReadPointer(actor + 0xF0);
			if (process == System.IntPtr.Zero) { throw new Eggceptions.NullException("process"); }

			return process;
		}

		/// <param name="actor">Actor</param>
		/// <param name="spellItem">SpellItem</param>
		static public void CastSpellPerkEntryPoint(System.IntPtr actor, System.IntPtr spellItem)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			if (spellItem == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("spellItem"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.CastSpellPerkEntryPoint, actor, spellItem);
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnFlyingMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnFlyingMount, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnMount, actor).ToBool();
		}

		/// <param name = "actor">Actor</param>
		/// <returns>MiddleHighProcessData</returns>
		static public System.IntPtr Update3DModel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var middleHighProcessData = NetScriptFramework.Memory.InvokeThisCall(Actor.GetProcess(actor), VIDS.Actor.Update3DModel, actor);
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.NullException("middleHighProcessData"); }

			return middleHighProcessData;
		}
	}
}
