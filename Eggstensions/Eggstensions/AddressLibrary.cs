namespace Eggstensions
{
	public class AddressLibrary
	{
		public enum ReadTypes : System.Byte
		{
			ReadUInt64			= 0,
			Add1				= 1,
			AddReadByte			= 2,
			SubtractReadByte	= 3,
			AddReadUInt16		= 4,
			SubtractReadUInt16	= 5,
			ReadUInt16			= 6,
			ReadUInt32			= 7
		}



		public class Header
		{
			public System.Int32 Format { get; set; }
			public System.Int32 VersionMajor { get; set; }
			public System.Int32 VersionMinor { get; set; }
			public System.Int32 VersionBuild { get; set; }
			public System.Int32 VersionPrivate { get; set; }
			public System.Int32 NameLength { get; set; }
			public System.String Name { get; set; }
			public System.Int32 PointerSize { get; set; }
			public System.Int32 AddressCount { get; set; }
		}



		static AddressLibrary()
		{
			AddressLibrary.FileInfo = new System.IO.FileInfo(System.IO.Path.Combine(Main.MainModuleDirectoryName, "Data", "SKSE", "Plugins", "version-" + Main.ProductVersion.Replace(".", "-") + ".bin"));
			AddressLibrary.offsets = AddressLibrary.Read(AddressLibrary.FileInfo);
		}



		static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> offsets { get; }



		static public System.IO.FileInfo FileInfo { get; }



		static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> Read(System.IO.FileInfo fileInfo)
		{
			using var fileStream = fileInfo.OpenRead();
			using var binaryReader = new System.IO.BinaryReader(fileStream, new System.Text.UTF8Encoding());

			return AddressLibrary.ReadFile(binaryReader, AddressLibrary.ReadHeader(binaryReader));
		}

		static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> ReadFile(System.IO.BinaryReader binaryReader, AddressLibrary.Header header)
		{
			var offsets = new System.Collections.Generic.SortedList<System.UInt64, System.IntPtr>(header.AddressCount);

			System.UInt64 identifier;
			System.UInt64 offset;
			System.UInt64 previousIdentifier = 0;
			System.UInt64 previousOffset = 0;

			for (var index = 0; index < header.AddressCount; index++)
			{
				var type = binaryReader.ReadByte();
				var identifierType = type & 0xF;
				var offsetType = type >> 4;

				switch ((AddressLibrary.ReadTypes)identifierType)
				{
					case AddressLibrary.ReadTypes.ReadUInt64:
					{
						identifier = binaryReader.ReadUInt64();

						break;
					}
					case AddressLibrary.ReadTypes.Add1:
					{
						identifier = previousIdentifier + 1;

						break;
					}
					case AddressLibrary.ReadTypes.AddReadByte:
					{
						identifier = previousIdentifier + binaryReader.ReadByte();

						break;
					}
					case AddressLibrary.ReadTypes.SubtractReadByte:
					{
						identifier = previousIdentifier - binaryReader.ReadByte();

						break;
					}
					case AddressLibrary.ReadTypes.AddReadUInt16:
					{
						identifier = previousIdentifier + binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.SubtractReadUInt16:
					{
						identifier = previousIdentifier - binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.ReadUInt16:
					{
						identifier = binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.ReadUInt32:
					{
						identifier = binaryReader.ReadUInt32();

						break;
					}
					default:
					{
						try
						{
							throw new System.InvalidOperationException(nameof(identifierType));
						}
						catch (System.Exception exception)
						{
							Log.WriteLine($"{exception}");

							throw;
						}
					}
				}

				var temporaryOffset = (offsetType & 8) != 0 ? previousOffset / (System.UInt64)header.PointerSize : previousOffset;

				switch ((AddressLibrary.ReadTypes)(offsetType & 7))
				{
					case AddressLibrary.ReadTypes.ReadUInt64:
					{
						offset = binaryReader.ReadUInt64();

						break;
					}
					case AddressLibrary.ReadTypes.Add1:
					{
						offset = temporaryOffset + 1;

						break;
					}
					case AddressLibrary.ReadTypes.AddReadByte:
					{
						offset = temporaryOffset + binaryReader.ReadByte();

						break;
					}
					case AddressLibrary.ReadTypes.SubtractReadByte:
					{
						offset = temporaryOffset - binaryReader.ReadByte();

						break;
					}
					case AddressLibrary.ReadTypes.AddReadUInt16:
					{
						offset = temporaryOffset + binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.SubtractReadUInt16:
					{
						offset = temporaryOffset - binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.ReadUInt16:
					{
						offset = binaryReader.ReadUInt16();

						break;
					}
					case AddressLibrary.ReadTypes.ReadUInt32:
					{
						offset = binaryReader.ReadUInt32();

						break;
					}
					default:
					{
						try
						{
							throw new System.InvalidOperationException(nameof(offsetType));
						}
						catch (System.Exception exception)
						{
							Log.WriteLine($"{exception}");

							throw;
						}
					}
				}

				if ((offsetType & 8) != 0)
				{
					offset *= (System.UInt64)header.PointerSize;
				}

				offsets.Add(identifier, new System.IntPtr((System.Int64)offset));

				previousIdentifier = identifier;
				previousOffset = offset;
			}

			return offsets;
		}

		static private AddressLibrary.Header ReadHeader(System.IO.BinaryReader binaryReader)
		{
			var header = new AddressLibrary.Header();
			header.Format = binaryReader.ReadInt32();

			if (header.Format != 1)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.Format));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.VersionMajor = binaryReader.ReadInt32();

			if (header.VersionMajor != Main.ProductVersionMajor)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.VersionMajor));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.VersionMinor = binaryReader.ReadInt32();

			if (header.VersionMinor != Main.ProductVersionMinor)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.VersionMinor));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.VersionBuild = binaryReader.ReadInt32();

			if (header.VersionBuild != Main.ProductVersionBuild)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.VersionBuild));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.VersionPrivate = binaryReader.ReadInt32();

			if (header.VersionPrivate != Main.ProductVersionPrivate)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.VersionPrivate));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.NameLength = binaryReader.ReadInt32();
			header.Name = new System.String(binaryReader.ReadChars(header.NameLength));

			if (header.Name != Main.MainModuleName)
			{
				try
				{
					throw new System.NotSupportedException(nameof(header.Name));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			header.PointerSize = binaryReader.ReadInt32();
			header.AddressCount = binaryReader.ReadInt32();

			return header;
		}



		static public System.IntPtr GetAddress(System.UInt64 identifier)
		{
			return new System.IntPtr(Main.MainModule.BaseAddress.ToInt64() + AddressLibrary.offsets[identifier].ToInt64());
		}

		static public System.IntPtr GetAddress(System.UInt64 identifier, System.Int32 offset)
		{
			return AddressLibrary.GetAddress(identifier) + offset;
		}

		static public System.IntPtr GetAddress(System.UInt64 identifier, System.Int32 addressOffset, System.Byte[] pattern, System.Int32 patternOffset = 0)
		{
			var address = AddressLibrary.GetAddress(identifier) + addressOffset;

			if (!Memory.Compare(address, patternOffset, pattern))
			{
				try
				{
					throw new System.InvalidProgramException(nameof(address));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			return address;
		}

		static public System.IntPtr GetAddress(System.UInt64 identifier, System.Int32 addressOffset, System.Byte?[] pattern, System.Int32 patternOffset = 0)
		{
			var address = AddressLibrary.GetAddress(identifier) + addressOffset;

			if (!Memory.Compare(address, patternOffset, pattern))
			{
				try
				{
					throw new System.InvalidProgramException(nameof(address));
				}
				catch (System.Exception exception)
				{
					Log.WriteLine($"{exception}");

					throw;
				}
			}

			return address;
		}
	}
}
