namespace Eggstensions.Bethesda
{
	static public class BSDismemberSkinInstance
	{
		/// <param name = "bsDismemberSkinInstance">BSDismemberSkinInstance</param>
		static public BipedObjectSlots GetBipedObjectSlot(System.IntPtr bsDismemberSkinInstance, System.UInt32 partitionIndex)
		{
			if (bsDismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsDismemberSkinInstance"); }
			if (partitionIndex >= BSDismemberSkinInstance.GetPartitionsCount(bsDismemberSkinInstance)) { throw new Eggceptions.ArgumentOutOfRangeException("partitionIndex"); }

			var partitions = NetScriptFramework.Memory.ReadPointer(bsDismemberSkinInstance + 0x90);
			if (partitions == System.IntPtr.Zero) { throw new Eggceptions.NullException("partitions"); }

			var bipedObjectSlot = NetScriptFramework.Memory.ReadUInt16(partitions + 0x2 + 0x4 * (System.Int32)partitionIndex);

			if ((System.UInt16)(bipedObjectSlot - 130) < 0x20)
			{
				bipedObjectSlot -= 100;
			}
			else if ((System.UInt16)(bipedObjectSlot - 230) < 0x20)
			{
				bipedObjectSlot -= 200;
			}

			return (BipedObjectSlots)bipedObjectSlot;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1CBD10 (VID15540)</summary>
		/// <param name = "bsDismemberSkinInstance">BSDismemberSkinInstance</param>
		static public System.Collections.Generic.List<BipedObjectSlots> GetBipedObjectSlots(System.IntPtr bsDismemberSkinInstance)
		{
			if (bsDismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsDismemberSkinInstance"); }

			var partitionsCount = BSDismemberSkinInstance.GetPartitionsCount(bsDismemberSkinInstance);
			var bipedObjectSlots = new System.Collections.Generic.List<BipedObjectSlots>();

			for (var i = 0u; i < partitionsCount; i++)
			{
				bipedObjectSlots.Add(BSDismemberSkinInstance.GetBipedObjectSlot(bsDismemberSkinInstance, i));
			}

			return bipedObjectSlots;
		}

		/// <param name = "bsDismemberSkinInstance">BSDismemberSkinInstance</param>
		static public System.UInt32 GetPartitionsCount(System.IntPtr bsDismemberSkinInstance)
		{
			if (bsDismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsDismemberSkinInstance"); }

			return NetScriptFramework.Memory.ReadUInt32(bsDismemberSkinInstance + 0x88);
		}

		// System.Byte
		/*
		/// <param name = "bsDismemberSkinInstance">BSDismemberSkinInstance</param>
		/// <returns>System.Boolean</returns>
		static public System.Boolean IsVisible(System.IntPtr bsDismemberSkinInstance)
		{
			if (bsDismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsDismemberSkinInstance"); }


		}

		/// <param name = "bsDismemberSkinInstance">BSDismemberSkinInstance</param>
		/// <param name = "partitionIndex">System.UInt32</param>
		/// <returns>System.Boolean</returns>
		static public System.Boolean IsVisible(System.IntPtr bsDismemberSkinInstance, System.UInt32 partitionIndex)
		{
			if (bsDismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsDismemberSkinInstance"); }
			if (partitionIndex >= BSDismemberSkinInstance.GetPartitionsCount(bsDismemberSkinInstance)) { throw new Eggceptions.ArgumentOutOfRangeException("partitionIndex"); }


		}
		*/
		// Is dismembered 0x98
		// Check the NiRTTI of the argument (e.g. NiAVObject, BSDismemberSkinInstance, etc.)

		/*
		void FUN_001cdd40(BSDismemberSkinInstance aSkin, short aBipedObjectSlot, undefined aVisible)
		{
			System.Int64 vOffset1;
			System.UInt32 vIterationCount1;
			System.UInt64 vIterationCount2;

			vIterationCount2 = 0;
			*(BSDismemberSkinInstance*)(aSkin + 0x98) = 0;

			if (*(System.Int32*)(aSkin + 0x88) != 0)
			{
				do
				{
					vOffset1 = vIterationCount2 * 4;

					if (*(System.Int16*)(vOffset1 + 2 + *(longlong*)(aSkin + 0x90)) == aBipedObjectSlot)
					{
						*(undefined*)(vOffset1 + *(longlong*)(aSkin + 0x90)) = aVisible;
					}

					vIterationCount1 = (System.Int32)vIterationCount2 + 1;
					*(System.Byte*)(aSkin + 0x98) = *(System.Byte*)(aSkin + 0x98) | *(System.Byte*)(vOffset1 + *(longlong*)(aSkin + 0x90));
					vIterationCount2 = (System.UInt64)vIterationCount1;
				}
				while (vIterationCount1 < *(System.UInt32*)(aSkin + 0x88));
			}

			return;
		}
		*/
		/*
		void FUN_001cdd40(BSDismemberSkinInstance aSkin, System.Int16 aBipedObjectSlot, System.Byte aVisible)
		{
			System.UInt32 iterationCount = 0;
			*(BSDismemberSkinInstance*)(aSkin + 0x98) = 0;
			
			System.Int32 partitionsCount = *(System.Int32*)(aSkin + 0x88);
			
			while (iterationCount < partitionsCount);
			{
				System.Int64 offset = 4 * iterationCount;
				
				if (*(System.Int16*)(*(longlong*)(aSkin + 0x90) + 2 + offset) == aBipedObjectSlot)
				{
					*(undefined*)(*(longlong*)(aSkin + 0x90) + offset) = aVisible;
				}
				
				*(System.Byte*)(aSkin + 0x98) |= *(System.Byte*)(*(longlong*)(aSkin + 0x90) + offset);
				iterationCount++;
			}
			
			return;
		}
		*/
		/*
		Partitions				(0x4)
		bool editorVisible;		(0x1)
		bool startNetBoneSet;	(0x1)
		std::uint16_t slot;		(0x2)
		*/
		/*
		0x98
		System.Byte visible		(0x1)
		*/
	}
}
