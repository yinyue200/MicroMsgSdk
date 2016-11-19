using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public abstract class ExtendableBuilderLite<TMessage, TBuilder> : GeneratedBuilderLite<TMessage, TBuilder> where TMessage : ExtendableMessageLite<TMessage, TBuilder> where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
	{
		public object this[IFieldDescriptorLite field, int index]
		{
			set
			{
				if (field.IsExtension)
				{
					ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
					extendableMessageLite.Extensions[field, index] = value;
					return;
				}
				throw new NotSupportedException("Not supported in the lite runtime.");
			}
		}

		public object this[IFieldDescriptorLite field]
		{
			set
			{
				if (field.IsExtension)
				{
					ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
					extendableMessageLite.Extensions[field] = value;
					return;
				}
				throw new NotSupportedException("Not supported in the lite runtime.");
			}
		}

		public bool HasExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			return messageBeingBuilt.HasExtension<TExtension>(extension);
		}

		public int GetExtensionCount<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			return messageBeingBuilt.GetExtensionCount<TExtension>(extension);
		}

		public TExtension GetExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			return messageBeingBuilt.GetExtension<TExtension>(extension);
		}

		public TExtension GetExtension<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension, int index)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			return messageBeingBuilt.GetExtension<TExtension>(extension, index);
		}

		public TBuilder SetExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension, TExtension value)
		{
			ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
			extendableMessageLite.VerifyExtensionContainingType<TExtension>(extension);
			extendableMessageLite.Extensions[extension.Descriptor] = extension.ToReflectionType(value);
			return this.ThisBuilder;
		}

		public TBuilder SetExtension<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension, int index, TExtension value)
		{
			ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
			extendableMessageLite.VerifyExtensionContainingType<IList<TExtension>>(extension);
			extendableMessageLite.Extensions[extension.Descriptor, index] = extension.SingularToReflectionType(value);
			return this.ThisBuilder;
		}

		public TBuilder AddExtension<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension, TExtension value)
		{
			ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
			extendableMessageLite.VerifyExtensionContainingType<IList<TExtension>>(extension);
			extendableMessageLite.Extensions.AddRepeatedField(extension.Descriptor, extension.SingularToReflectionType(value));
			return this.ThisBuilder;
		}

		public TBuilder ClearExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
			extendableMessageLite.VerifyExtensionContainingType<TExtension>(extension);
			extendableMessageLite.Extensions.ClearField(extension.Descriptor);
			return this.ThisBuilder;
		}

		
		protected override bool ParseUnknownField(ICodedInputStream input, ExtensionRegistry extensionRegistry, uint tag, string fieldName)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			FieldSet extensions = messageBeingBuilt.Extensions;
			WireFormat.WireType tagWireType = WireFormat.GetTagWireType(tag);
			int tagFieldNumber = WireFormat.GetTagFieldNumber(tag);
			IGeneratedExtensionLite generatedExtensionLite = extensionRegistry[this.DefaultInstanceForType, tagFieldNumber];
			if (generatedExtensionLite == null)
			{
				return input.SkipField();
			}
			IFieldDescriptorLite descriptor = generatedExtensionLite.Descriptor;
			if (descriptor == null)
			{
				return input.SkipField();
			}
			WireFormat.WireType wireType = descriptor.IsPacked ? WireFormat.WireType.LengthDelimited : WireFormat.GetWireType(descriptor.FieldType);
			if (tagWireType != wireType)
			{
				wireType = WireFormat.GetWireType(descriptor.FieldType);
				if (tagWireType != wireType && (!descriptor.IsRepeated || tagWireType != WireFormat.WireType.LengthDelimited || (wireType != WireFormat.WireType.Varint && wireType != WireFormat.WireType.Fixed32 && wireType != WireFormat.WireType.Fixed64)))
				{
					return input.SkipField();
				}
			}
			if (!descriptor.IsRepeated && tagWireType != WireFormat.GetWireType(descriptor.FieldType))
			{
				return input.SkipField();
			}
			FieldType fieldType = descriptor.FieldType;
			switch (fieldType)
			{
			case FieldType.Group:
			case FieldType.Message:
			{
				if (descriptor.IsRepeated)
				{
					List<IMessageLite> list = new List<IMessageLite>();
					if (descriptor.FieldType == FieldType.Group)
					{
						input.ReadGroupArray<IMessageLite>(tag, fieldName, list, generatedExtensionLite.MessageDefaultInstance, extensionRegistry);
					}
					else
					{
						input.ReadMessageArray<IMessageLite>(tag, fieldName, list, generatedExtensionLite.MessageDefaultInstance, extensionRegistry);
					}
					using (List<IMessageLite>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							IMessageLite current = enumerator.Current;
							extensions.AddRepeatedField(descriptor, current);
						}
					}
					return true;
				}
				IMessageLite messageLite = extensions[generatedExtensionLite.Descriptor] as IMessageLite;
				IBuilderLite builderLite = (messageLite ?? generatedExtensionLite.MessageDefaultInstance).WeakToBuilder();
				if (descriptor.FieldType == FieldType.Group)
				{
					input.ReadGroup(descriptor.FieldNumber, builderLite, extensionRegistry);
				}
				else
				{
					input.ReadMessage(builderLite, extensionRegistry);
				}
				extensions[descriptor] = builderLite.WeakBuild();
				break;
			}
			default:
				if (fieldType == FieldType.Enum)
				{
					if (!descriptor.IsRepeated)
					{
						IEnumLite value = null;
						object obj;
						if (input.ReadEnum(ref value, out obj, descriptor.EnumType))
						{
							extensions[descriptor] = value;
							break;
						}
						break;
					}
					else
					{
						List<IEnumLite> list2 = new List<IEnumLite>();
						ICollection<object> collection;
						input.ReadEnumArray(tag, fieldName, list2, out collection, descriptor.EnumType);
						using (List<IEnumLite>.Enumerator enumerator2 = list2.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								IEnumLite current2 = enumerator2.Current;
								extensions.AddRepeatedField(descriptor, current2);
							}
							break;
						}
					}
				}
				if (!descriptor.IsRepeated)
				{
					object value2 = null;
					if (input.ReadPrimitiveField(descriptor.FieldType, ref value2))
					{
						extensions[descriptor] = value2;
					}
				}
				else
				{
					List<object> list3 = new List<object>();
					input.ReadPrimitiveArray(descriptor.FieldType, tag, fieldName, list3);
					using (List<object>.Enumerator enumerator3 = list3.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							object current3 = enumerator3.Current;
							extensions.AddRepeatedField(descriptor, current3);
						}
					}
				}
				break;
			}
			return true;
		}

		public TBuilder ClearField(IFieldDescriptorLite field)
		{
			if (field.IsExtension)
			{
				ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
				extendableMessageLite.Extensions.ClearField(field);
				return this.ThisBuilder;
			}
			throw new NotSupportedException("Not supported in the lite runtime.");
		}

		public TBuilder AddRepeatedField(IFieldDescriptorLite field, object value)
		{
			if (field.IsExtension)
			{
				ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = this.MessageBeingBuilt;
				extendableMessageLite.Extensions.AddRepeatedField(field, value);
				return this.ThisBuilder;
			}
			throw new NotSupportedException("Not supported in the lite runtime.");
		}

		protected void MergeExtensionFields(ExtendableMessageLite<TMessage, TBuilder> other)
		{
			TMessage messageBeingBuilt = this.MessageBeingBuilt;
			messageBeingBuilt.Extensions.MergeFrom(other.Extensions);
		}
	}
}
