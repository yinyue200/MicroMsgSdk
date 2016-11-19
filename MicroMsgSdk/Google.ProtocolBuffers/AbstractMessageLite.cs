using System;
using System.IO;

namespace Google.ProtocolBuffers
{
	public abstract class AbstractMessageLite<TMessage, TBuilder> : IMessageLite<TMessage, TBuilder>, IMessageLite<TMessage>, IMessageLite where TMessage : AbstractMessageLite<TMessage, TBuilder> where TBuilder : AbstractBuilderLite<TMessage, TBuilder>
	{
		public abstract TMessage DefaultInstanceForType
		{
			get;
		}

		public abstract bool IsInitialized
		{
			get;
		}

		public abstract int SerializedSize
		{
			get;
		}

		IMessageLite IMessageLite.WeakDefaultInstanceForType
		{
			get
			{
				return this.DefaultInstanceForType;
			}
		}

		public abstract TBuilder CreateBuilderForType();

		public abstract TBuilder ToBuilder();

		public abstract void WriteTo(ICodedOutputStream output);

		public abstract void PrintTo(TextWriter writer);

		public ByteString ToByteString()
		{
			ByteString.CodedBuilder codedBuilder = new ByteString.CodedBuilder(this.SerializedSize);
			this.WriteTo(codedBuilder.CodedOutput);
			return codedBuilder.Build();
		}

		public byte[] ToByteArray()
		{
			byte[] array = new byte[this.SerializedSize];
			CodedOutputStream codedOutputStream = CodedOutputStream.CreateInstance(array);
			this.WriteTo(codedOutputStream);
			codedOutputStream.CheckNoSpaceLeft();
			return array;
		}

		public void WriteTo(Stream output)
		{
			CodedOutputStream codedOutputStream = CodedOutputStream.CreateInstance(output);
			this.WriteTo(codedOutputStream);
			codedOutputStream.Flush();
		}

		public void WriteDelimitedTo(Stream output)
		{
			CodedOutputStream codedOutputStream = CodedOutputStream.CreateInstance(output);
			codedOutputStream.WriteRawVarint32((uint)this.SerializedSize);
			this.WriteTo(codedOutputStream);
			codedOutputStream.Flush();
		}

		IBuilderLite IMessageLite.WeakCreateBuilderForType()
		{
			return this.CreateBuilderForType();
		}

		IBuilderLite IMessageLite.WeakToBuilder()
		{
			return this.ToBuilder();
		}
	}
}
