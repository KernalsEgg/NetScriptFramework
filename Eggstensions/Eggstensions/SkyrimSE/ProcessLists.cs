﻿namespace Eggstensions.SkyrimSE
{
	static public class ProcessLists
	{
		/// <returns>ProcessLists</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.ProcessLists.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.HandleAddress GetHighActorHandleAddresses(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.HandleAddress(processLists + 0x30);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.Handle GetHighActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.Handle(processLists + 0x30);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.ReferenceFromHandle GetHighActors(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.ReferenceFromHandle(processLists + 0x30);
		}

		/// <param name="processLists">ProcessLists</param>
		static public System.Int32 GetHighActorHandlesCount(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return NetScriptFramework.Memory.ReadInt32(processLists + 0x10);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.HandleAddress GetLowActorHandleAddresses(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.HandleAddress(processLists + 0x48);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.Handle GetLowActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.Handle(processLists + 0x48);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.ReferenceFromHandle GetLowActors(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.ReferenceFromHandle(processLists + 0x48);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.HandleAddress GetMiddleHighActorHandleAddresses(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.HandleAddress(processLists + 0x60);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.Handle GetMiddleHighActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.Handle(processLists + 0x60);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.ReferenceFromHandle GetMiddleHighActors(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.ReferenceFromHandle(processLists + 0x60);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.HandleAddress GetMiddleLowActorHandleAddresses(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.HandleAddress(processLists + 0x78);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.Handle GetMiddleLowActorHandles(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.Handle(processLists + 0x78);
		}

		/// <param name="processLists">ProcessLists</param>
		static public BSTArray.ReferenceFromHandle GetMiddleLowActors(System.IntPtr processLists)
		{
			if (processLists == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(processLists)); }

			return new BSTArray.ReferenceFromHandle(processLists + 0x78);
		}
	}
}