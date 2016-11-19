using Google.ProtocolBuffers.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Google.ProtocolBuffers.Descriptors
{
	public sealed class FieldMappingAttribute : Attribute
	{
		private static readonly IDictionary<FieldType, FieldMappingAttribute> FieldTypeToMappedTypeMap = FieldMappingAttribute.MapFieldTypes();

		public MappedType MappedType
		{
			get;
			private set;
		}

		public WireFormat.WireType WireType
		{
			get;
			private set;
		}

		public FieldMappingAttribute(MappedType mappedType, WireFormat.WireType wireType)
		{
			this.MappedType = mappedType;
			this.WireType = wireType;
		}

		private static IDictionary<FieldType, FieldMappingAttribute> MapFieldTypes()
		{
			Dictionary<FieldType, FieldMappingAttribute> dictionary = new Dictionary<FieldType, FieldMappingAttribute>();
			FieldInfo[] fields = typeof(FieldType).GetFields((BindingFlags)24);
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				FieldType fieldType = (FieldType)fieldInfo.GetValue(null);
				FieldMappingAttribute fieldMappingAttribute = (FieldMappingAttribute)fieldInfo.GetCustomAttributes(typeof(FieldMappingAttribute), false).GetEnumerator().Current;
				dictionary[fieldType]= fieldMappingAttribute;
			}
			return Dictionaries.AsReadOnly<FieldType, FieldMappingAttribute>(dictionary);
		}

		internal static MappedType MappedTypeFromFieldType(FieldType type)
		{
			return FieldMappingAttribute.FieldTypeToMappedTypeMap[type].MappedType;
		}

		internal static WireFormat.WireType WireTypeFromFieldType(FieldType type, bool packed)
		{
			if (!packed)
			{
				return FieldMappingAttribute.FieldTypeToMappedTypeMap[type].WireType;
			}
			return WireFormat.WireType.LengthDelimited;
		}
	}
}
