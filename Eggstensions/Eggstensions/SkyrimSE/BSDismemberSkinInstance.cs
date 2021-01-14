namespace Eggstensions.SkyrimSE
{
	static public class BSDismemberSkinInstance
	{
		/// <summary>SkyrimSE.exe + 0x1CBD10 (VID15540)</summary>
		/// <param name = "dismemberSkinInstance">BSDismemberSkinInstance</param>
		static public System.Collections.Generic.List<BipedObjectSlots> GetBipedObjectSlots(System.IntPtr dismemberSkinInstance)
		{
			if (dismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dismemberSkinInstance)); }

			var bipedObjectSlots = new System.Collections.Generic.List<BipedObjectSlots>();

			var partitionsCount = BSDismemberSkinInstance.GetPartitionsCount(dismemberSkinInstance);
			var partitions = BSDismemberSkinInstance.GetPartitions(dismemberSkinInstance);

			for (var i = 0; i < partitionsCount; i++)
			{
				var bipedObjectSlot = NetScriptFramework.Memory.ReadUInt16(partitions + 0x2 + 0x4 * i);

				if ((System.UInt16)(bipedObjectSlot - 130) < 0x20)
				{
					bipedObjectSlot -= 100;
				}
				else if ((System.UInt16)(bipedObjectSlot - 230) < 0x20)
				{
					bipedObjectSlot -= 200;
				}

				bipedObjectSlots.Add((BipedObjectSlots)bipedObjectSlot);
			}

			return bipedObjectSlots;
		}

		/// <param name = "dismemberSkinInstance">BSDismemberSkinInstance</param>
		static public System.IntPtr GetPartitions(System.IntPtr dismemberSkinInstance)
		{
			if (dismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dismemberSkinInstance)); }

			var partitions = NetScriptFramework.Memory.ReadPointer(dismemberSkinInstance + 0x90);
			if (partitions == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(partitions)); }

			return partitions;
		}

		/// <param name = "dismemberSkinInstance">BSDismemberSkinInstance</param>
		static public System.UInt32 GetPartitionsCount(System.IntPtr dismemberSkinInstance)
		{
			if (dismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dismemberSkinInstance)); }

			return NetScriptFramework.Memory.ReadUInt32(dismemberSkinInstance + 0x88);
		}

		// System.Byte
		/*
		/// <param name = "dismemberSkinInstance">BSDismemberSkinInstance</param>
		/// <returns>System.Boolean</returns>
		static public System.Boolean IsVisible(System.IntPtr dismemberSkinInstance)
		{
			if (dismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dismemberSkinInstance)); }


		}

		/// <param name = "dismemberSkinInstance">BSDismemberSkinInstance</param>
		/// <param name = "partitionIndex">System.UInt32</param>
		/// <returns>System.Boolean</returns>
		static public System.Boolean IsVisible(System.IntPtr dismemberSkinInstance, System.UInt32 partitionIndex)
		{
			if (dismemberSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dismemberSkinInstance)); }
			if (partitionIndex >= BSDismemberSkinInstance.GetPartitionsCount(dismemberSkinInstance)) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(partitionIndex)); }


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
