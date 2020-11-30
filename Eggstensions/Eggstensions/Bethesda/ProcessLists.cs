namespace Eggstensions.Bethesda
{
	static public class ProcessLists
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBEAD0 (VID514167)</summary>
		/// <returns>ProcessLists</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(514167);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="processLists">ProcessLists</param>
		/// <returns>BSTArray&lt;ActorHandle&gt;</returns>
		static public System.IntPtr GetHighActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("processLists"); }

			return processLists + 0x30;
		}

		/// <param name="processLists">ProcessLists</param>
		static public System.Int32 GetHighActorHandlesCount(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("processLists"); }

			return NetScriptFramework.Memory.ReadInt32(processLists + 0x10);
		}

		/// <param name="processLists">ProcessLists</param>
		/// <returns>BSTArray&lt;ActorHandle&gt;</returns>
		static public System.IntPtr GetLowActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("processLists"); }

			return processLists + 0x48;
		}

		/// <param name="processLists">ProcessLists</param>
		/// <returns>BSTArray&lt;ActorHandle&gt;</returns>
		static public System.IntPtr GetMiddleHighActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("processLists"); }

			return processLists + 0x60;
		}

		/// <param name="processLists">ProcessLists</param>
		/// <returns>BSTArray&lt;ActorHandle&gt;</returns>
		static public System.IntPtr GetMiddleLowActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("processLists"); }

			return processLists + 0x78;
		}
	}
}
