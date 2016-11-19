using System;
using System.IO;

namespace Google.ProtocolBuffers
{
	public abstract class AbstractBuilderLite<TMessage, TBuilder> : IBuilderLite<TMessage, TBuilder>, IBuilderLite where TMessage : AbstractMessageLite<TMessage, TBuilder> where TBuilder : AbstractBuilderLite<TMessage, TBuilder>
	{
		private class LimitedInputStream : Stream
		{
			private readonly Stream proxied;

			private int bytesLeft;

			public override bool CanRead
			{
				get
				{
					return true;
				}
			}

			public override bool CanSeek
			{
				get
				{
					return false;
				}
			}

			public override bool CanWrite
			{
				get
				{
					return false;
				}
			}

			public override long Length
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			public override long Position
			{
				get
				{
					throw new NotSupportedException();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			internal LimitedInputStream(Stream proxied, int size)
			{
				this.proxied = proxied;
				this.bytesLeft = size;
			}

			public override void Flush()
			{
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				if (this.bytesLeft > 0)
				{
					int num = this.proxied.Read(buffer, offset, Math.Min(this.bytesLeft, count));
					this.bytesLeft -= num;
					return num;
				}
				return 0;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}
		}

		protected abstract TBuilder ThisBuilder
		{
			get;
		}

		public abstract bool IsInitialized
		{
			get;
		}

		public abstract TMessage DefaultInstanceForType
		{
			get;
		}

		IMessageLite IBuilderLite.WeakDefaultInstanceForType
		{
			get
			{
				return this.DefaultInstanceForType;
			}
		}

		public abstract TBuilder Clear();

		public abstract TBuilder Clone();

		public abstract TMessage Build();

		public abstract TMessage BuildPartial();

		public abstract TBuilder MergeFrom(IMessageLite other);

		public abstract TBuilder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry);

		public virtual TBuilder MergeFrom(ICodedInputStream input)
		{
			return this.MergeFrom(input, ExtensionRegistry.CreateInstance());
		}

		public TBuilder MergeDelimitedFrom(Stream input)
		{
			return this.MergeDelimitedFrom(input, ExtensionRegistry.CreateInstance());
		}

		public TBuilder MergeDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
		{
			int size = (int)CodedInputStream.ReadRawVarint32(input);
			Stream input2 = new AbstractBuilderLite<TMessage, TBuilder>.LimitedInputStream(input, size);
			return this.MergeFrom(input2, extensionRegistry);
		}

		public TBuilder MergeFrom(ByteString data)
		{
			return this.MergeFrom(data, ExtensionRegistry.CreateInstance());
		}

		public TBuilder MergeFrom(ByteString data, ExtensionRegistry extensionRegistry)
		{
			CodedInputStream codedInputStream = data.CreateCodedInput();
			this.MergeFrom(codedInputStream, extensionRegistry);
			codedInputStream.CheckLastTagWas(0u);
			return this.ThisBuilder;
		}

		public TBuilder MergeFrom(byte[] data)
		{
			CodedInputStream codedInputStream = CodedInputStream.CreateInstance(data);
			this.MergeFrom(codedInputStream);
			codedInputStream.CheckLastTagWas(0u);
			return this.ThisBuilder;
		}

		public TBuilder MergeFrom(byte[] data, ExtensionRegistry extensionRegistry)
		{
			CodedInputStream codedInputStream = CodedInputStream.CreateInstance(data);
			this.MergeFrom(codedInputStream, extensionRegistry);
			codedInputStream.CheckLastTagWas(0u);
			return this.ThisBuilder;
		}

		public TBuilder MergeFrom(Stream input)
		{
			CodedInputStream codedInputStream = CodedInputStream.CreateInstance(input);
			this.MergeFrom(codedInputStream);
			codedInputStream.CheckLastTagWas(0u);
			return this.ThisBuilder;
		}

		public TBuilder MergeFrom(Stream input, ExtensionRegistry extensionRegistry)
		{
			CodedInputStream codedInputStream = CodedInputStream.CreateInstance(input);
			this.MergeFrom(codedInputStream, extensionRegistry);
			codedInputStream.CheckLastTagWas(0u);
			return this.ThisBuilder;
		}

		IBuilderLite IBuilderLite.WeakClear()
		{
			return this.Clear();
		}

		IBuilderLite IBuilderLite.WeakMergeFrom(IMessageLite message)
		{
			return this.MergeFrom(message);
		}

		IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data)
		{
			return this.MergeFrom(data);
		}

		IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data, ExtensionRegistry registry)
		{
			return this.MergeFrom(data, registry);
		}

		IBuilderLite IBuilderLite.WeakMergeFrom(ICodedInputStream input)
		{
			return this.MergeFrom(input);
		}

		IBuilderLite IBuilderLite.WeakMergeFrom(ICodedInputStream input, ExtensionRegistry registry)
		{
			return this.MergeFrom(input, registry);
		}

		IMessageLite IBuilderLite.WeakBuild()
		{
			return this.Build();
		}

		IMessageLite IBuilderLite.WeakBuildPartial()
		{
			return this.BuildPartial();
		}

		IBuilderLite IBuilderLite.WeakClone()
		{
			return this.Clone();
		}
	}
}
