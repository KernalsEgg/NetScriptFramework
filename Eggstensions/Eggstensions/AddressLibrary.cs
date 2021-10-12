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



		readonly static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> offsets = AddressLibrary.Read(Main.ProductVersionMajor, Main.ProductVersionMinor, Main.ProductVersionBuild, Main.ProductVersionPrivate);



		static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> Read(System.Int32 versionMajor, System.Int32 versionMinor, System.Int32 versionBuild, System.Int32 versionPrivate)
		{
			try
			{
				var fileInfo = new System.IO.FileInfo(System.IO.Path.Combine(Main.MainModuleDirectoryName, "Data", "SKSE", "Plugins", $"version-{versionMajor}-{versionMinor}-{versionBuild}-{versionPrivate}.bin"));
				using var fileStream = fileInfo.OpenRead();
				using var binaryReader = new System.IO.BinaryReader(fileStream, new System.Text.UTF8Encoding());

				return AddressLibrary.ReadFile(binaryReader, AddressLibrary.ReadHeader(binaryReader, versionMajor, versionMinor, versionBuild, versionPrivate));
			}
			catch (System.Exception exception) // System.IO.FileNotFoundException
			{
				Log.Information($"{exception}");

				throw;
			}
		}

		static private System.Collections.Generic.SortedList<System.UInt64, System.IntPtr> ReadFile(System.IO.BinaryReader binaryReader, AddressLibrary.Header header)
		{
			var offsets = new System.Collections.Generic.SortedList<System.UInt64, System.IntPtr>(header.AddressCount);

			System.UInt64 identifier;
			System.UInt64 offset;

			System.UInt64 previousIdentifier	= 0;
			System.UInt64 previousOffset		= 0;

			for (var index = 0; index < header.AddressCount; index++)
			{
				var type			= binaryReader.ReadByte();
				var identifierType	= type & 0xF;
				var offsetType		= type >> 4;

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
							throw new System.InvalidOperationException($"{nameof(AddressLibrary)}: Unexpected {nameof(identifierType)} encountered, {identifierType}.");
						}
						catch (System.InvalidOperationException invalidOperationException)
						{
							Log.Information($"{invalidOperationException}");

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
							throw new System.InvalidOperationException($"{nameof(AddressLibrary)}: Unexpected {nameof(offsetType)} encountered, {offsetType}.");
						}
						catch (System.InvalidOperationException invalidOperationException)
						{
							Log.Information($"{invalidOperationException}");

							throw;
						}
					}
				}

				if ((offsetType & 8) != 0)
				{
					offset *= (System.UInt64)header.PointerSize;
				}

				offsets.Add(identifier, new System.IntPtr((System.Int64)offset));

				previousIdentifier	= identifier;
				previousOffset		= offset;
			}

			return offsets;
		}

		static private AddressLibrary.Header ReadHeader(System.IO.BinaryReader binaryReader, System.Int32 versionMajor, System.Int32 versionMinor, System.Int32 versionBuild, System.Int32 versionPrivate)
		{
			var header		= new AddressLibrary.Header();
			header.Format	= binaryReader.ReadInt32();

			if (header.Format != 1)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.Format)} encountered, {header.Format}. Expected 1");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.VersionMajor = binaryReader.ReadInt32();

			if (header.VersionMajor != versionMajor)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.VersionMajor)} encountered, {header.VersionMajor}. Expected {versionMajor}");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.VersionMinor = binaryReader.ReadInt32();

			if (header.VersionMinor != versionMinor)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.VersionMinor)} encountered, {header.VersionMinor}. Expected {versionMinor}");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.VersionBuild = binaryReader.ReadInt32();

			if (header.VersionBuild != versionBuild)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.VersionBuild)} encountered, {header.VersionBuild}. Expected {versionBuild}");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.VersionPrivate = binaryReader.ReadInt32();

			if (header.VersionPrivate != versionPrivate)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.VersionPrivate)} encountered, {header.VersionPrivate}. Expected {versionPrivate}");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.NameLength	= binaryReader.ReadInt32();
			header.Name			= new System.String(binaryReader.ReadChars(header.NameLength));

			if (header.Name != Main.MainModuleName)
			{
				try
				{
					throw new System.NotSupportedException($"{nameof(AddressLibrary)}: Unexpected {nameof(header.Name)} encountered, {header.Name}. Expected {Main.MainModuleName}");
				}
				catch (System.NotSupportedException notSupportedException)
				{
					Log.Information($"{notSupportedException}");

					throw;
				}
			}

			header.PointerSize	= binaryReader.ReadInt32();
			header.AddressCount	= binaryReader.ReadInt32();

			return header;
		}



		static public void Dump(System.String path)
		{
			var streamWriter = new System.IO.StreamWriter(path, false);

			foreach (var offset in AddressLibrary.offsets)
			{
				streamWriter.WriteLine($"{offset.Key}\t{offset.Value:X}");
			}

			streamWriter.Close();
		}

		static public void Dump(System.String path, System.Int32 versionMajor, System.Int32 versionMinor, System.Int32 versionBuild, System.Int32 versionPrivate)
		{
			var streamWriter	= new System.IO.StreamWriter(path, false);
			var offsets			= AddressLibrary.Read(versionMajor, versionMinor, versionBuild, versionPrivate);

			foreach (var offset in offsets)
			{
				streamWriter.WriteLine($"{offset.Key}\t{offset.Value:X}");
			}

			streamWriter.Close();
		}

		static public System.IntPtr GetAddress(System.UInt64 identifier)
		{
			return new System.IntPtr(Main.MainModule.BaseAddress.ToInt64() + AddressLibrary.offsets[identifier].ToInt64());
		}

		static public System.IntPtr GetAddress(System.UInt64 identifier, System.Int32 offset)
		{
			return AddressLibrary.GetAddress(identifier) + offset;
		}

		static public System.Boolean MatchPattern(System.IntPtr address, System.Byte[] pattern)
		{
			var equals = Memory.Equals<System.Byte>(address, pattern);

			if (!equals)
			{
				Log.Information($"{nameof(AddressLibrary)}: Unexpected {nameof(pattern)} encountered at {Main.MainModuleName} + {address.ToInt64() - Main.MainModule.BaseAddress.ToInt64():X}, {System.Convert.ToHexString(Memory.ReadArray<System.Byte>(address, pattern.Length))}. Expected {System.Convert.ToHexString(pattern)}.");
			}

			return equals;
		}

		static public System.Boolean MatchPattern(System.IntPtr address, System.Byte[] pattern, System.Int32 offset)
		{
			return AddressLibrary.MatchPattern(address + offset, pattern);
		}

		static public System.Boolean MatchPattern(System.IntPtr address, System.Byte?[] pattern)
		{
			var equals = Memory.Equals<System.Byte>(address, pattern);

			if (!equals)
			{
				Log.Information($"{nameof(AddressLibrary)}: Unexpected {nameof(pattern)} encountered at {Main.MainModuleName} + {address.ToInt64() - Main.MainModule.BaseAddress.ToInt64():X}, {System.Convert.ToHexString(Memory.ReadArray<System.Byte>(address, pattern.Length))}.");
			}

			return equals;
		}

		static public System.Boolean MatchPattern(System.IntPtr address, System.Byte?[] pattern, System.Int32 offset)
		{
			return AddressLibrary.MatchPattern(address + offset, pattern);
		}
	}
}
