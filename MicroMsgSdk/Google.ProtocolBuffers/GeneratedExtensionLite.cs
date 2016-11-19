using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public class GeneratedExtensionLite<TContainingType, TExtensionType> : IGeneratedExtensionLite where TContainingType : IMessageLite
	{
		private readonly TContainingType containingTypeDefaultInstance;

		private readonly TExtensionType defaultValue;

		private readonly IMessageLite messageDefaultInstance;

		private readonly ExtensionDescriptorLite descriptor;

		private static readonly IList<object> Empty = new object[0];

		public IFieldDescriptorLite Descriptor
		{
			get
			{
				return this.descriptor;
			}
		}

		public TExtensionType DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
		}

		object IGeneratedExtensionLite.ContainingType
		{
			get
			{
				return this.ContainingTypeDefaultInstance;
			}
		}

		public TContainingType ContainingTypeDefaultInstance
		{
			get
			{
				return this.containingTypeDefaultInstance;
			}
		}

		public int Number
		{
			get
			{
				return this.descriptor.FieldNumber;
			}
		}

		public IMessageLite MessageDefaultInstance
		{
			get
			{
				return this.messageDefaultInstance;
			}
		}

		protected GeneratedExtensionLite(TContainingType containingTypeDefaultInstance, TExtensionType defaultValue, IMessageLite messageDefaultInstance, ExtensionDescriptorLite descriptor)
		{
			this.containingTypeDefaultInstance = containingTypeDefaultInstance;
			this.messageDefaultInstance = messageDefaultInstance;
			this.defaultValue = defaultValue;
			this.descriptor = descriptor;
		}

		public GeneratedExtensionLite(string fullName, TContainingType containingTypeDefaultInstance, TExtensionType defaultValue, IMessageLite messageDefaultInstance, IEnumLiteMap enumTypeMap, int number, FieldType type) : this(containingTypeDefaultInstance, defaultValue, messageDefaultInstance, new ExtensionDescriptorLite(fullName, enumTypeMap, number, type, defaultValue, false, false))
		{
		}

		protected GeneratedExtensionLite(string fullName, TContainingType containingTypeDefaultInstance, TExtensionType defaultValue, IMessageLite messageDefaultInstance, IEnumLiteMap enumTypeMap, int number, FieldType type, bool isPacked) : this(containingTypeDefaultInstance, defaultValue, messageDefaultInstance, new ExtensionDescriptorLite(fullName, enumTypeMap, number, type, GeneratedExtensionLite<TContainingType, TExtensionType>.Empty, true, isPacked))
		{
		}

		public virtual object ToReflectionType(object value)
		{
			return this.SingularToReflectionType(value);
		}

		public object SingularToReflectionType(object value)
		{
			if (this.descriptor.MappedType != MappedType.Enum)
			{
				return value;
			}
			return this.descriptor.EnumType.FindValueByNumber((int)value);
		}

		public virtual object FromReflectionType(object value)
		{
			return this.SingularFromReflectionType(value);
		}

		public object SingularFromReflectionType(object value)
		{
			switch (this.Descriptor.MappedType)
			{
			case MappedType.Message:
				if (value is TExtensionType)
				{
					return value;
				}
				return this.MessageDefaultInstance.WeakCreateBuilderForType().WeakMergeFrom((IMessageLite)value).WeakBuild();
			case MappedType.Enum:
			{
				IEnumLite enumLite = (IEnumLite)value;
				return enumLite.Number;
			}
			default:
				return value;
			}
		}
	}
}
