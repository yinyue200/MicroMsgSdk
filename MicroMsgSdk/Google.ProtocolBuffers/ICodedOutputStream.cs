using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public interface ICodedOutputStream
	{
		void WriteMessageStart();

		void WriteMessageEnd();

		void Flush();

		[Obsolete]
		void WriteUnknownGroup(int fieldNumber, IMessageLite value);

		void WriteUnknownBytes(int fieldNumber, ByteString value);

		
		void WriteUnknownField(int fieldNumber, WireFormat.WireType wireType, ulong value);

		void WriteMessageSetExtension(int fieldNumber, string fieldName, IMessageLite value);

		void WriteMessageSetExtension(int fieldNumber, string fieldName, ByteString value);

		void WriteField(FieldType fieldType, int fieldNumber, string fieldName, object value);

		void WriteDouble(int fieldNumber, string fieldName, double value);

		void WriteFloat(int fieldNumber, string fieldName, float value);

		
		void WriteUInt64(int fieldNumber, string fieldName, ulong value);

		void WriteInt64(int fieldNumber, string fieldName, long value);

		void WriteInt32(int fieldNumber, string fieldName, int value);

		
		void WriteFixed64(int fieldNumber, string fieldName, ulong value);

		
		void WriteFixed32(int fieldNumber, string fieldName, uint value);

		void WriteBool(int fieldNumber, string fieldName, bool value);

		void WriteString(int fieldNumber, string fieldName, string value);

		void WriteGroup(int fieldNumber, string fieldName, IMessageLite value);

		void WriteMessage(int fieldNumber, string fieldName, IMessageLite value);

		void WriteBytes(int fieldNumber, string fieldName, ByteString value);

		
		void WriteUInt32(int fieldNumber, string fieldName, uint value);

		void WriteEnum(int fieldNumber, string fieldName, int value, object rawValue);

		void WriteSFixed32(int fieldNumber, string fieldName, int value);

		void WriteSFixed64(int fieldNumber, string fieldName, long value);

		void WriteSInt32(int fieldNumber, string fieldName, int value);

		void WriteSInt64(int fieldNumber, string fieldName, long value);

		void WriteArray(FieldType fieldType, int fieldNumber, string fieldName, IEnumerable list);

		void WriteGroupArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : IMessageLite;

		void WriteMessageArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : IMessageLite;

		void WriteStringArray(int fieldNumber, string fieldName, IEnumerable<string> list);

		void WriteBytesArray(int fieldNumber, string fieldName, IEnumerable<ByteString> list);

		void WriteBoolArray(int fieldNumber, string fieldName, IEnumerable<bool> list);

		void WriteInt32Array(int fieldNumber, string fieldName, IEnumerable<int> list);

		void WriteSInt32Array(int fieldNumber, string fieldName, IEnumerable<int> list);

		void WriteUInt32Array(int fieldNumber, string fieldName, IEnumerable<uint> list);

		void WriteFixed32Array(int fieldNumber, string fieldName, IEnumerable<uint> list);

		void WriteSFixed32Array(int fieldNumber, string fieldName, IEnumerable<int> list);

		void WriteInt64Array(int fieldNumber, string fieldName, IEnumerable<long> list);

		void WriteSInt64Array(int fieldNumber, string fieldName, IEnumerable<long> list);

		void WriteUInt64Array(int fieldNumber, string fieldName, IEnumerable<ulong> list);

		void WriteFixed64Array(int fieldNumber, string fieldName, IEnumerable<ulong> list);

		void WriteSFixed64Array(int fieldNumber, string fieldName, IEnumerable<long> list);

		void WriteDoubleArray(int fieldNumber, string fieldName, IEnumerable<double> list);

		void WriteFloatArray(int fieldNumber, string fieldName, IEnumerable<float> list);

		
		void WriteEnumArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : struct, IComparable, IFormattable, IConvertible;

		void WritePackedArray(FieldType fieldType, int fieldNumber, string fieldName, IEnumerable list);

		void WritePackedBoolArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<bool> list);

		void WritePackedInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list);

		void WritePackedSInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list);

		void WritePackedUInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<uint> list);

		void WritePackedFixed32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<uint> list);

		void WritePackedSFixed32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list);

		void WritePackedInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list);

		void WritePackedSInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list);

		void WritePackedUInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<ulong> list);

		void WritePackedFixed64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<ulong> list);

		void WritePackedSFixed64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list);

		void WritePackedDoubleArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<double> list);

		void WritePackedFloatArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<float> list);

		
		void WritePackedEnumArray<T>(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<T> list) where T : struct, IComparable, IFormattable, IConvertible;
	}
}
