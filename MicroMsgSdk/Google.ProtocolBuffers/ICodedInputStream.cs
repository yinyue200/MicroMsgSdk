using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public interface ICodedInputStream
	{
		bool IsAtEnd
		{
			get;
		}

		void ReadMessageStart();

		void ReadMessageEnd();

		
		bool ReadTag(out uint fieldTag, out string fieldName);

		bool ReadDouble(ref double value);

		bool ReadFloat(ref float value);

		
		bool ReadUInt64(ref ulong value);

		bool ReadInt64(ref long value);

		bool ReadInt32(ref int value);

		
		bool ReadFixed64(ref ulong value);

		
		bool ReadFixed32(ref uint value);

		bool ReadBool(ref bool value);

		bool ReadString(ref string value);

		void ReadGroup(int fieldNumber, IBuilderLite builder, ExtensionRegistry extensionRegistry);

		[Obsolete]
		void ReadUnknownGroup(int fieldNumber, IBuilderLite builder);

		void ReadMessage(IBuilderLite builder, ExtensionRegistry extensionRegistry);

		bool ReadBytes(ref ByteString value);

		
		bool ReadUInt32(ref uint value);

		bool ReadEnum(ref IEnumLite value, out object unknown, IEnumLiteMap mapping);

		
		bool ReadEnum<T>(ref T value, out object unknown) where T : struct, IComparable, IFormattable, IConvertible;

		bool ReadSFixed32(ref int value);

		bool ReadSFixed64(ref long value);

		bool ReadSInt32(ref int value);

		bool ReadSInt64(ref long value);

		
		void ReadPrimitiveArray(FieldType fieldType, uint fieldTag, string fieldName, ICollection<object> list);

		
		void ReadEnumArray(uint fieldTag, string fieldName, ICollection<IEnumLite> list, out ICollection<object> unknown, IEnumLiteMap mapping);

		
		void ReadEnumArray<T>(uint fieldTag, string fieldName, ICollection<T> list, out ICollection<object> unknown) where T : struct, IComparable, IFormattable, IConvertible;

		
		void ReadMessageArray<T>(uint fieldTag, string fieldName, ICollection<T> list, T messageType, ExtensionRegistry registry) where T : IMessageLite;

		
		void ReadGroupArray<T>(uint fieldTag, string fieldName, ICollection<T> list, T messageType, ExtensionRegistry registry) where T : IMessageLite;

		bool ReadPrimitiveField(FieldType fieldType, ref object value);

		
		bool SkipField();

		
		void ReadStringArray(uint fieldTag, string fieldName, ICollection<string> list);

		
		void ReadBytesArray(uint fieldTag, string fieldName, ICollection<ByteString> list);

		
		void ReadBoolArray(uint fieldTag, string fieldName, ICollection<bool> list);

		
		void ReadInt32Array(uint fieldTag, string fieldName, ICollection<int> list);

		
		void ReadSInt32Array(uint fieldTag, string fieldName, ICollection<int> list);

		
		void ReadUInt32Array(uint fieldTag, string fieldName, ICollection<uint> list);

		
		void ReadFixed32Array(uint fieldTag, string fieldName, ICollection<uint> list);

		
		void ReadSFixed32Array(uint fieldTag, string fieldName, ICollection<int> list);

		
		void ReadInt64Array(uint fieldTag, string fieldName, ICollection<long> list);

		
		void ReadSInt64Array(uint fieldTag, string fieldName, ICollection<long> list);

		
		void ReadUInt64Array(uint fieldTag, string fieldName, ICollection<ulong> list);

		
		void ReadFixed64Array(uint fieldTag, string fieldName, ICollection<ulong> list);

		
		void ReadSFixed64Array(uint fieldTag, string fieldName, ICollection<long> list);

		
		void ReadDoubleArray(uint fieldTag, string fieldName, ICollection<double> list);

		
		void ReadFloatArray(uint fieldTag, string fieldName, ICollection<float> list);
	}
}
