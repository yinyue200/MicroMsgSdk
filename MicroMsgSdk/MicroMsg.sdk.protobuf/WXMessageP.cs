using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXMessageP : GeneratedMessageLite<WXMessageP, WXMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXMessageP, WXMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXMessageP result;

			protected override WXMessageP.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			protected override WXMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXMessageP DefaultInstanceForType
			{
				get
				{
					return WXMessageP.DefaultInstance;
				}
			}

			public uint Type
			{
				get
				{
					return this.result.Type;
				}
				set
				{
					this.SetType(value);
				}
			}

			public string Title
			{
				get
				{
					return this.result.Title;
				}
				set
				{
					this.SetTitle(value);
				}
			}

			public string Description
			{
				get
				{
					return this.result.Description;
				}
				set
				{
					this.SetDescription(value);
				}
			}

			public ByteString ThumbData
			{
				get
				{
					return this.result.ThumbData;
				}
				set
				{
					this.SetThumbData(value);
				}
			}

			public WXEmojiMessageP EmojiMessage
			{
				get
				{
					return this.result.EmojiMessage;
				}
				set
				{
					this.SetEmojiMessage(value);
				}
			}

			public WXFileMessageP FileMessage
			{
				get
				{
					return this.result.FileMessage;
				}
				set
				{
					this.SetFileMessage(value);
				}
			}

			public WXImageMessageP ImageMessage
			{
				get
				{
					return this.result.ImageMessage;
				}
				set
				{
					this.SetImageMessage(value);
				}
			}

			public WXMusicMessageP MusicMessage
			{
				get
				{
					return this.result.MusicMessage;
				}
				set
				{
					this.SetMusicMessage(value);
				}
			}

			public WXTextMessageP TextMessage
			{
				get
				{
					return this.result.TextMessage;
				}
				set
				{
					this.SetTextMessage(value);
				}
			}

			public WXVideoMessageP VideoMessage
			{
				get
				{
					return this.result.VideoMessage;
				}
				set
				{
					this.SetVideoMessage(value);
				}
			}

			public WXWebpageMessageP WebpageMessage
			{
				get
				{
					return this.result.WebpageMessage;
				}
				set
				{
					this.SetWebpageMessage(value);
				}
			}

			public WXAppExtendMessageP AppExtendMessage
			{
				get
				{
					return this.result.AppExtendMessage;
				}
				set
				{
					this.SetAppExtendMessage(value);
				}
			}

			public Builder()
			{
				this.result = WXMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXMessageP other = this.result;
					this.result = new WXMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXMessageP.Builder Clear()
			{
				this.result = WXMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXMessageP.Builder(this.result);
				}
				return new WXMessageP.Builder().MergeFrom(this.result);
			}

			public override WXMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXMessageP)
				{
					return this.MergeFrom((WXMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXMessageP.Builder MergeFrom(WXMessageP other)
			{
				return this;
			}

			public override WXMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXMessageP._wXMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXMessageP._wXMessagePFieldTags[num2];
					}
					uint num3 = num;
					if (num3 <= 42u)
					{
						if (num3 <= 18u)
						{
							if (num3 == 0u)
							{
								throw InvalidProtocolBufferException.InvalidTag();
							}
							if (num3 == 8u)
							{
								this.result.hasType = input.ReadUInt32(ref this.result.type_);
								continue;
							}
							if (num3 == 18u)
							{
								this.result.hasTitle = input.ReadString(ref this.result.title_);
								continue;
							}
						}
						else
						{
							if (num3 == 26u)
							{
								this.result.hasDescription = input.ReadString(ref this.result.description_);
								continue;
							}
							if (num3 == 34u)
							{
								this.result.hasThumbData = input.ReadBytes(ref this.result.thumbData_);
								continue;
							}
							if (num3 == 42u)
							{
								WXEmojiMessageP.Builder builder = WXEmojiMessageP.CreateBuilder();
								if (this.result.hasEmojiMessage)
								{
									builder.MergeFrom(this.EmojiMessage);
								}
								input.ReadMessage(builder, extensionRegistry);
								this.EmojiMessage = builder.BuildPartial();
								continue;
							}
						}
					}
					else if (num3 <= 66u)
					{
						if (num3 == 50u)
						{
							WXFileMessageP.Builder builder2 = WXFileMessageP.CreateBuilder();
							if (this.result.hasFileMessage)
							{
								builder2.MergeFrom(this.FileMessage);
							}
							input.ReadMessage(builder2, extensionRegistry);
							this.FileMessage = builder2.BuildPartial();
							continue;
						}
						if (num3 == 58u)
						{
							WXImageMessageP.Builder builder3 = WXImageMessageP.CreateBuilder();
							if (this.result.hasImageMessage)
							{
								builder3.MergeFrom(this.ImageMessage);
							}
							input.ReadMessage(builder3, extensionRegistry);
							this.ImageMessage = builder3.BuildPartial();
							continue;
						}
						if (num3 == 66u)
						{
							WXMusicMessageP.Builder builder4 = WXMusicMessageP.CreateBuilder();
							if (this.result.hasMusicMessage)
							{
								builder4.MergeFrom(this.MusicMessage);
							}
							input.ReadMessage(builder4, extensionRegistry);
							this.MusicMessage = builder4.BuildPartial();
							continue;
						}
					}
					else if (num3 <= 82u)
					{
						if (num3 == 74u)
						{
							WXTextMessageP.Builder builder5 = WXTextMessageP.CreateBuilder();
							if (this.result.hasTextMessage)
							{
								builder5.MergeFrom(this.TextMessage);
							}
							input.ReadMessage(builder5, extensionRegistry);
							this.TextMessage = builder5.BuildPartial();
							continue;
						}
						if (num3 == 82u)
						{
							WXVideoMessageP.Builder builder6 = WXVideoMessageP.CreateBuilder();
							if (this.result.hasVideoMessage)
							{
								builder6.MergeFrom(this.VideoMessage);
							}
							input.ReadMessage(builder6, extensionRegistry);
							this.VideoMessage = builder6.BuildPartial();
							continue;
						}
					}
					else
					{
						if (num3 == 90u)
						{
							WXWebpageMessageP.Builder builder7 = WXWebpageMessageP.CreateBuilder();
							if (this.result.hasWebpageMessage)
							{
								builder7.MergeFrom(this.WebpageMessage);
							}
							input.ReadMessage(builder7, extensionRegistry);
							this.WebpageMessage = builder7.BuildPartial();
							continue;
						}
						if (num3 == 98u)
						{
							WXAppExtendMessageP.Builder builder8 = WXAppExtendMessageP.CreateBuilder();
							if (this.result.hasAppExtendMessage)
							{
								builder8.MergeFrom(this.AppExtendMessage);
							}
							input.ReadMessage(builder8, extensionRegistry);
							this.AppExtendMessage = builder8.BuildPartial();
							continue;
						}
					}
					if (WireFormat.IsEndGroupTag(num))
					{
						return this;
					}
					this.ParseUnknownField(input, extensionRegistry, num, text);
				}
				return this;
			}

			public WXMessageP.Builder SetType(uint value)
			{
				this.PrepareBuilder();
				this.result.hasType = true;
				this.result.type_ = value;
				return this;
			}

			public WXMessageP.Builder ClearType()
			{
				this.PrepareBuilder();
				this.result.hasType = false;
				this.result.type_ = 0u;
				return this;
			}

			public WXMessageP.Builder SetTitle(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTitle = true;
				this.result.title_ = value;
				return this;
			}

			public WXMessageP.Builder ClearTitle()
			{
				this.PrepareBuilder();
				this.result.hasTitle = false;
				this.result.title_ = "";
				return this;
			}

			public WXMessageP.Builder SetDescription(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasDescription = true;
				this.result.description_ = value;
				return this;
			}

			public WXMessageP.Builder ClearDescription()
			{
				this.PrepareBuilder();
				this.result.hasDescription = false;
				this.result.description_ = "";
				return this;
			}

			public WXMessageP.Builder SetThumbData(ByteString value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasThumbData = true;
				this.result.thumbData_ = value;
				return this;
			}

			public WXMessageP.Builder ClearThumbData()
			{
				this.PrepareBuilder();
				this.result.hasThumbData = false;
				this.result.thumbData_ = ByteString.Empty;
				return this;
			}

			public WXMessageP.Builder SetEmojiMessage(WXEmojiMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasEmojiMessage = true;
				this.result.emojiMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetEmojiMessage(WXEmojiMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasEmojiMessage = true;
				this.result.emojiMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeEmojiMessage(WXEmojiMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasEmojiMessage && this.result.emojiMessage_ != WXEmojiMessageP.DefaultInstance)
				{
					this.result.emojiMessage_ = WXEmojiMessageP.CreateBuilder(this.result.emojiMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.emojiMessage_ = value;
				}
				this.result.hasEmojiMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearEmojiMessage()
			{
				this.PrepareBuilder();
				this.result.hasEmojiMessage = false;
				this.result.emojiMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetFileMessage(WXFileMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFileMessage = true;
				this.result.fileMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetFileMessage(WXFileMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasFileMessage = true;
				this.result.fileMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeFileMessage(WXFileMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasFileMessage && this.result.fileMessage_ != WXFileMessageP.DefaultInstance)
				{
					this.result.fileMessage_ = WXFileMessageP.CreateBuilder(this.result.fileMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.fileMessage_ = value;
				}
				this.result.hasFileMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearFileMessage()
			{
				this.PrepareBuilder();
				this.result.hasFileMessage = false;
				this.result.fileMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetImageMessage(WXImageMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasImageMessage = true;
				this.result.imageMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetImageMessage(WXImageMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasImageMessage = true;
				this.result.imageMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeImageMessage(WXImageMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasImageMessage && this.result.imageMessage_ != WXImageMessageP.DefaultInstance)
				{
					this.result.imageMessage_ = WXImageMessageP.CreateBuilder(this.result.imageMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.imageMessage_ = value;
				}
				this.result.hasImageMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearImageMessage()
			{
				this.PrepareBuilder();
				this.result.hasImageMessage = false;
				this.result.imageMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetMusicMessage(WXMusicMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMusicMessage = true;
				this.result.musicMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetMusicMessage(WXMusicMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasMusicMessage = true;
				this.result.musicMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeMusicMessage(WXMusicMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasMusicMessage && this.result.musicMessage_ != WXMusicMessageP.DefaultInstance)
				{
					this.result.musicMessage_ = WXMusicMessageP.CreateBuilder(this.result.musicMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.musicMessage_ = value;
				}
				this.result.hasMusicMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearMusicMessage()
			{
				this.PrepareBuilder();
				this.result.hasMusicMessage = false;
				this.result.musicMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetTextMessage(WXTextMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTextMessage = true;
				this.result.textMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetTextMessage(WXTextMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasTextMessage = true;
				this.result.textMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeTextMessage(WXTextMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasTextMessage && this.result.textMessage_ != WXTextMessageP.DefaultInstance)
				{
					this.result.textMessage_ = WXTextMessageP.CreateBuilder(this.result.textMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.textMessage_ = value;
				}
				this.result.hasTextMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearTextMessage()
			{
				this.PrepareBuilder();
				this.result.hasTextMessage = false;
				this.result.textMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetVideoMessage(WXVideoMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasVideoMessage = true;
				this.result.videoMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetVideoMessage(WXVideoMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasVideoMessage = true;
				this.result.videoMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeVideoMessage(WXVideoMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasVideoMessage && this.result.videoMessage_ != WXVideoMessageP.DefaultInstance)
				{
					this.result.videoMessage_ = WXVideoMessageP.CreateBuilder(this.result.videoMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.videoMessage_ = value;
				}
				this.result.hasVideoMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearVideoMessage()
			{
				this.PrepareBuilder();
				this.result.hasVideoMessage = false;
				this.result.videoMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetWebpageMessage(WXWebpageMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasWebpageMessage = true;
				this.result.webpageMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetWebpageMessage(WXWebpageMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasWebpageMessage = true;
				this.result.webpageMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeWebpageMessage(WXWebpageMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasWebpageMessage && this.result.webpageMessage_ != WXWebpageMessageP.DefaultInstance)
				{
					this.result.webpageMessage_ = WXWebpageMessageP.CreateBuilder(this.result.webpageMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.webpageMessage_ = value;
				}
				this.result.hasWebpageMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearWebpageMessage()
			{
				this.PrepareBuilder();
				this.result.hasWebpageMessage = false;
				this.result.webpageMessage_ = null;
				return this;
			}

			public WXMessageP.Builder SetAppExtendMessage(WXAppExtendMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAppExtendMessage = true;
				this.result.appExtendMessage_ = value;
				return this;
			}

			public WXMessageP.Builder SetAppExtendMessage(WXAppExtendMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasAppExtendMessage = true;
				this.result.appExtendMessage_ = builderForValue.Build();
				return this;
			}

			public WXMessageP.Builder MergeAppExtendMessage(WXAppExtendMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasAppExtendMessage && this.result.appExtendMessage_ != WXAppExtendMessageP.DefaultInstance)
				{
					this.result.appExtendMessage_ = WXAppExtendMessageP.CreateBuilder(this.result.appExtendMessage_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.appExtendMessage_ = value;
				}
				this.result.hasAppExtendMessage = true;
				return this;
			}

			public WXMessageP.Builder ClearAppExtendMessage()
			{
				this.PrepareBuilder();
				this.result.hasAppExtendMessage = false;
				this.result.appExtendMessage_ = null;
				return this;
			}
		}

		public const int TypeFieldNumber = 1;

		public const int TitleFieldNumber = 2;

		public const int DescriptionFieldNumber = 3;

		public const int ThumbDataFieldNumber = 4;

		public const int EmojiMessageFieldNumber = 5;

		public const int FileMessageFieldNumber = 6;

		public const int ImageMessageFieldNumber = 7;

		public const int MusicMessageFieldNumber = 8;

		public const int TextMessageFieldNumber = 9;

		public const int VideoMessageFieldNumber = 10;

		public const int WebpageMessageFieldNumber = 11;

		public const int AppExtendMessageFieldNumber = 12;

		private static readonly WXMessageP defaultInstance;

		private static readonly string[] _wXMessagePFieldNames;

		private static readonly uint[] _wXMessagePFieldTags;

		private bool hasType;

		private uint type_;

		private bool hasTitle;

		private string title_ = "";

		private bool hasDescription;

		private string description_ = "";

		private bool hasThumbData;

		private ByteString thumbData_ = ByteString.Empty;

		private bool hasEmojiMessage;

		private WXEmojiMessageP emojiMessage_;

		private bool hasFileMessage;

		private WXFileMessageP fileMessage_;

		private bool hasImageMessage;

		private WXImageMessageP imageMessage_;

		private bool hasMusicMessage;

		private WXMusicMessageP musicMessage_;

		private bool hasTextMessage;

		private WXTextMessageP textMessage_;

		private bool hasVideoMessage;

		private WXVideoMessageP videoMessage_;

		private bool hasWebpageMessage;

		private WXWebpageMessageP webpageMessage_;

		private bool hasAppExtendMessage;

		private WXAppExtendMessageP appExtendMessage_;

		private int memoizedSerializedSize = -1;

		public static WXMessageP DefaultInstance
		{
			get
			{
				return WXMessageP.defaultInstance;
			}
		}

		public override WXMessageP DefaultInstanceForType
		{
			get
			{
				return WXMessageP.DefaultInstance;
			}
		}

		protected override WXMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public uint Type
		{
			get
			{
				return this.type_;
			}
		}

		public string Title
		{
			get
			{
				return this.title_;
			}
		}

		public string Description
		{
			get
			{
				return this.description_;
			}
		}

		public ByteString ThumbData
		{
			get
			{
				return this.thumbData_;
			}
		}

		public WXEmojiMessageP EmojiMessage
		{
			get
			{
				return this.emojiMessage_ ?? WXEmojiMessageP.DefaultInstance;
			}
		}

		public WXFileMessageP FileMessage
		{
			get
			{
				return this.fileMessage_ ?? WXFileMessageP.DefaultInstance;
			}
		}

		public WXImageMessageP ImageMessage
		{
			get
			{
				return this.imageMessage_ ?? WXImageMessageP.DefaultInstance;
			}
		}

		public WXMusicMessageP MusicMessage
		{
			get
			{
				return this.musicMessage_ ?? WXMusicMessageP.DefaultInstance;
			}
		}

		public WXTextMessageP TextMessage
		{
			get
			{
				return this.textMessage_ ?? WXTextMessageP.DefaultInstance;
			}
		}

		public WXVideoMessageP VideoMessage
		{
			get
			{
				return this.videoMessage_ ?? WXVideoMessageP.DefaultInstance;
			}
		}

		public WXWebpageMessageP WebpageMessage
		{
			get
			{
				return this.webpageMessage_ ?? WXWebpageMessageP.DefaultInstance;
			}
		}

		public WXAppExtendMessageP AppExtendMessage
		{
			get
			{
				return this.appExtendMessage_ ?? WXAppExtendMessageP.DefaultInstance;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasType;
			}
		}

		public override int SerializedSize
		{
			get
			{
				int num = this.memoizedSerializedSize;
				if (num != -1)
				{
					return num;
				}
				num = 0;
				if (this.hasType)
				{
					num += CodedOutputStream.ComputeUInt32Size(1, this.Type);
				}
				if (this.hasTitle)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.Title);
				}
				if (this.hasDescription)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.Description);
				}
				if (this.hasThumbData)
				{
					num += CodedOutputStream.ComputeBytesSize(4, this.ThumbData);
				}
				if (this.hasEmojiMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(5, this.EmojiMessage);
				}
				if (this.hasFileMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(6, this.FileMessage);
				}
				if (this.hasImageMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(7, this.ImageMessage);
				}
				if (this.hasMusicMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(8, this.MusicMessage);
				}
				if (this.hasTextMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(9, this.TextMessage);
				}
				if (this.hasVideoMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(10, this.VideoMessage);
				}
				if (this.hasWebpageMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(11, this.WebpageMessage);
				}
				if (this.hasAppExtendMessage)
				{
					num += CodedOutputStream.ComputeMessageSize(12, this.AppExtendMessage);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXMessagePFieldNames = WXMessageP._wXMessagePFieldNames;
			if (this.hasType)
			{
				output.WriteUInt32(1, wXMessagePFieldNames[9], this.Type);
			}
			if (this.hasTitle)
			{
				output.WriteString(2, wXMessagePFieldNames[8], this.Title);
			}
			if (this.hasDescription)
			{
				output.WriteString(3, wXMessagePFieldNames[1], this.Description);
			}
			if (this.hasThumbData)
			{
				output.WriteBytes(4, wXMessagePFieldNames[7], this.ThumbData);
			}
			if (this.hasEmojiMessage)
			{
				output.WriteMessage(5, wXMessagePFieldNames[2], this.EmojiMessage);
			}
			if (this.hasFileMessage)
			{
				output.WriteMessage(6, wXMessagePFieldNames[3], this.FileMessage);
			}
			if (this.hasImageMessage)
			{
				output.WriteMessage(7, wXMessagePFieldNames[4], this.ImageMessage);
			}
			if (this.hasMusicMessage)
			{
				output.WriteMessage(8, wXMessagePFieldNames[5], this.MusicMessage);
			}
			if (this.hasTextMessage)
			{
				output.WriteMessage(9, wXMessagePFieldNames[6], this.TextMessage);
			}
			if (this.hasVideoMessage)
			{
				output.WriteMessage(10, wXMessagePFieldNames[10], this.VideoMessage);
			}
			if (this.hasWebpageMessage)
			{
				output.WriteMessage(11, wXMessagePFieldNames[11], this.WebpageMessage);
			}
			if (this.hasAppExtendMessage)
			{
				output.WriteMessage(12, wXMessagePFieldNames[0], this.AppExtendMessage);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasType)
			{
				num ^= this.type_.GetHashCode();
			}
			if (this.hasTitle)
			{
				num ^= this.title_.GetHashCode();
			}
			if (this.hasDescription)
			{
				num ^= this.description_.GetHashCode();
			}
			if (this.hasThumbData)
			{
				num ^= this.thumbData_.GetHashCode();
			}
			if (this.hasEmojiMessage)
			{
				num ^= this.emojiMessage_.GetHashCode();
			}
			if (this.hasFileMessage)
			{
				num ^= this.fileMessage_.GetHashCode();
			}
			if (this.hasImageMessage)
			{
				num ^= this.imageMessage_.GetHashCode();
			}
			if (this.hasMusicMessage)
			{
				num ^= this.musicMessage_.GetHashCode();
			}
			if (this.hasTextMessage)
			{
				num ^= this.textMessage_.GetHashCode();
			}
			if (this.hasVideoMessage)
			{
				num ^= this.videoMessage_.GetHashCode();
			}
			if (this.hasWebpageMessage)
			{
				num ^= this.webpageMessage_.GetHashCode();
			}
			if (this.hasAppExtendMessage)
			{
				num ^= this.appExtendMessage_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXMessageP wXMessageP = obj as WXMessageP;
			return wXMessageP != null && this.hasType == wXMessageP.hasType && (!this.hasType || this.type_.Equals(wXMessageP.type_)) && this.hasTitle == wXMessageP.hasTitle && (!this.hasTitle || this.title_.Equals(wXMessageP.title_)) && this.hasDescription == wXMessageP.hasDescription && (!this.hasDescription || this.description_.Equals(wXMessageP.description_)) && this.hasThumbData == wXMessageP.hasThumbData && (!this.hasThumbData || this.thumbData_.Equals(wXMessageP.thumbData_)) && this.hasEmojiMessage == wXMessageP.hasEmojiMessage && (!this.hasEmojiMessage || this.emojiMessage_.Equals(wXMessageP.emojiMessage_)) && this.hasFileMessage == wXMessageP.hasFileMessage && (!this.hasFileMessage || this.fileMessage_.Equals(wXMessageP.fileMessage_)) && this.hasImageMessage == wXMessageP.hasImageMessage && (!this.hasImageMessage || this.imageMessage_.Equals(wXMessageP.imageMessage_)) && this.hasMusicMessage == wXMessageP.hasMusicMessage && (!this.hasMusicMessage || this.musicMessage_.Equals(wXMessageP.musicMessage_)) && this.hasTextMessage == wXMessageP.hasTextMessage && (!this.hasTextMessage || this.textMessage_.Equals(wXMessageP.textMessage_)) && this.hasVideoMessage == wXMessageP.hasVideoMessage && (!this.hasVideoMessage || this.videoMessage_.Equals(wXMessageP.videoMessage_)) && this.hasWebpageMessage == wXMessageP.hasWebpageMessage && (!this.hasWebpageMessage || this.webpageMessage_.Equals(wXMessageP.webpageMessage_)) && this.hasAppExtendMessage == wXMessageP.hasAppExtendMessage && (!this.hasAppExtendMessage || this.appExtendMessage_.Equals(wXMessageP.appExtendMessage_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("Type", this.hasType, this.type_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("Title", this.hasTitle, this.title_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("Description", this.hasDescription, this.description_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("ThumbData", this.hasThumbData, this.thumbData_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("EmojiMessage", this.hasEmojiMessage, this.emojiMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("FileMessage", this.hasFileMessage, this.fileMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("ImageMessage", this.hasImageMessage, this.imageMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("MusicMessage", this.hasMusicMessage, this.musicMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("TextMessage", this.hasTextMessage, this.textMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("VideoMessage", this.hasVideoMessage, this.videoMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("WebpageMessage", this.hasWebpageMessage, this.webpageMessage_, writer);
			GeneratedMessageLite<WXMessageP, WXMessageP.Builder>.PrintField("AppExtendMessage", this.hasAppExtendMessage, this.appExtendMessage_, writer);
		}

		public static WXMessageP ParseFrom(byte[] data)
		{
			return WXMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXMessageP.Builder CreateBuilder()
		{
			return new WXMessageP.Builder();
		}

		public override WXMessageP.Builder ToBuilder()
		{
			return WXMessageP.CreateBuilder(this);
		}

		public override WXMessageP.Builder CreateBuilderForType()
		{
			return new WXMessageP.Builder();
		}

		public static WXMessageP.Builder CreateBuilder(WXMessageP prototype)
		{
			return new WXMessageP.Builder(prototype);
		}

		static WXMessageP()
		{
			WXMessageP.defaultInstance = new WXMessageP().MakeReadOnly();
			WXMessageP._wXMessagePFieldNames = new string[]
			{
				"AppExtendMessage",
				"Description",
				"EmojiMessage",
				"FileMessage",
				"ImageMessage",
				"MusicMessage",
				"TextMessage",
				"ThumbData",
				"Title",
				"Type",
				"VideoMessage",
				"WebpageMessage"
			};
			WXMessageP._wXMessagePFieldTags = new uint[]
			{
				98u,
				26u,
				42u,
				50u,
				58u,
				66u,
				74u,
				34u,
				18u,
				8u,
				82u,
				90u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXMessageP.Descriptor, null);
		}
	}
}
