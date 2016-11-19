using Google.ProtocolBuffers.Descriptors;
using System;

namespace Google.ProtocolBuffers
{
	public static class WireFormat
	{
		
		public enum WireType : uint
		{
			Varint,
			Fixed64,
			LengthDelimited,
			StartGroup,
			EndGroup,
			Fixed32
		}

		internal static class MessageSetField
		{
			internal const int Item = 1;

			internal const int TypeID = 2;

			internal const int Message = 3;
		}

		internal static class MessageSetTag
		{
			internal static readonly uint ItemStart = WireFormat.MakeTag(1, WireFormat.WireType.StartGroup);

			internal static readonly uint ItemEnd = WireFormat.MakeTag(1, WireFormat.WireType.EndGroup);

			internal static readonly uint TypeID = WireFormat.MakeTag(2, WireFormat.WireType.Varint);

			internal static readonly uint Message = WireFormat.MakeTag(3, WireFormat.WireType.LengthDelimited);
		}

		public const int Fixed32Size = 4;

		public const int Fixed64Size = 8;

		public const int SFixed32Size = 4;

		public const int SFixed64Size = 8;

		public const int FloatSize = 4;

		public const int DoubleSize = 8;

		public const int BoolSize = 1;

		private const int TagTypeBits = 3;

		private const uint TagTypeMask = 7u;

		
		public static WireFormat.WireType GetTagWireType(uint tag)
		{
			return (WireFormat.WireType)(tag & 7u);
		}

		
		public static bool IsEndGroupTag(uint tag)
		{
			return (tag & 7u) == 4u;
		}

		
		public static int GetTagFieldNumber(uint tag)
		{
			return (int)tag >> 3;
		}

		
		public static uint MakeTag(int fieldNumber, WireFormat.WireType wireType)
		{
			return (uint)(fieldNumber << 3 | (int)wireType);
		}

		
		public static WireFormat.WireType GetWireType(FieldType fieldType)
		{
			switch (fieldType)
			{
			case FieldType.Double:
				return WireFormat.WireType.Fixed64;
			case FieldType.Float:
				return WireFormat.WireType.Fixed32;
			case FieldType.Int64:
			case FieldType.UInt64:
			case FieldType.Int32:
				return WireFormat.WireType.Varint;
			case FieldType.Fixed64:
				return WireFormat.WireType.Fixed64;
			case FieldType.Fixed32:
				return WireFormat.WireType.Fixed32;
			case FieldType.Bool:
				return WireFormat.WireType.Varint;
			case FieldType.String:
				return WireFormat.WireType.LengthDelimited;
			case FieldType.Group:
				return WireFormat.WireType.StartGroup;
			case FieldType.Message:
			case FieldType.Bytes:
				return WireFormat.WireType.LengthDelimited;
			case FieldType.UInt32:
				return WireFormat.WireType.Varint;
			case FieldType.SFixed32:
				return WireFormat.WireType.Fixed32;
			case FieldType.SFixed64:
				return WireFormat.WireType.Fixed64;
			case FieldType.SInt32:
			case FieldType.SInt64:
			case FieldType.Enum:
				return WireFormat.WireType.Varint;
			default:
				throw new ArgumentOutOfRangeException("No such field type");
			}
		}
	}
}
