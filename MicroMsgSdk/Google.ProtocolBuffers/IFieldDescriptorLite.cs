using Google.ProtocolBuffers.Descriptors;
using System;

namespace Google.ProtocolBuffers
{
	public interface IFieldDescriptorLite : IComparable<IFieldDescriptorLite>
	{
		bool IsRepeated
		{
			get;
		}

		bool IsRequired
		{
			get;
		}

		bool IsPacked
		{
			get;
		}

		bool IsExtension
		{
			get;
		}

		bool MessageSetWireFormat
		{
			get;
		}

		int FieldNumber
		{
			get;
		}

		string Name
		{
			get;
		}

		string FullName
		{
			get;
		}

		IEnumLiteMap EnumType
		{
			get;
		}

		FieldType FieldType
		{
			get;
		}

		MappedType MappedType
		{
			get;
		}

		object DefaultValue
		{
			get;
		}
	}
}
