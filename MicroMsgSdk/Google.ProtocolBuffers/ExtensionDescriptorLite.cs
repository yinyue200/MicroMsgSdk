using Google.ProtocolBuffers.Descriptors;
using System;

namespace Google.ProtocolBuffers
{
	public class ExtensionDescriptorLite : IFieldDescriptorLite, IComparable<IFieldDescriptorLite>
	{
		private readonly string fullName;

		private readonly IEnumLiteMap enumTypeMap;

		private readonly int number;

		private readonly FieldType type;

		private readonly bool isRepeated;

		private readonly bool isPacked;

		private readonly MappedType mapType;

		private readonly object defaultValue;

		public string Name
		{
			get
			{
				string text = this.fullName;
				int num = text.LastIndexOf('.');
				if (num >= 0)
				{
					text = text.Substring(num);
				}
				return text;
			}
		}

		public string FullName
		{
			get
			{
				return this.fullName;
			}
		}

		public bool IsRepeated
		{
			get
			{
				return this.isRepeated;
			}
		}

		public bool IsRequired
		{
			get
			{
				return false;
			}
		}

		public bool IsPacked
		{
			get
			{
				return this.isPacked;
			}
		}

		public bool IsExtension
		{
			get
			{
				return true;
			}
		}

		public bool MessageSetWireFormat
		{
			get
			{
				return false;
			}
		}

		public int FieldNumber
		{
			get
			{
				return this.number;
			}
		}

		public IEnumLiteMap EnumType
		{
			get
			{
				return this.enumTypeMap;
			}
		}

		public FieldType FieldType
		{
			get
			{
				return this.type;
			}
		}

		public MappedType MappedType
		{
			get
			{
				return this.mapType;
			}
		}

		public object DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
		}

		public ExtensionDescriptorLite(string fullName, IEnumLiteMap enumTypeMap, int number, FieldType type, object defaultValue, bool isRepeated, bool isPacked)
		{
			this.fullName = fullName;
			this.enumTypeMap = enumTypeMap;
			this.number = number;
			this.type = type;
			this.mapType = FieldMappingAttribute.MappedTypeFromFieldType(type);
			this.isRepeated = isRepeated;
			this.isPacked = isPacked;
			this.defaultValue = defaultValue;
		}

		public int CompareTo(IFieldDescriptorLite other)
		{
			return this.FieldNumber.CompareTo(other.FieldNumber);
		}
	}
}
