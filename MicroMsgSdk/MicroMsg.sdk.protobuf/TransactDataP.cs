using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class TransactDataP : GeneratedMessageLite<TransactDataP, TransactDataP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<TransactDataP, TransactDataP.Builder>
		{
			private bool resultIsReadOnly;

			private TransactDataP result;

			protected override TransactDataP.Builder ThisBuilder
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

			protected override TransactDataP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override TransactDataP DefaultInstanceForType
			{
				get
				{
					return TransactDataP.DefaultInstance;
				}
			}

			public uint ConmandID
			{
				get
				{
					return this.result.ConmandID;
				}
				set
				{
					this.SetConmandID(value);
				}
			}

			public string AppID
			{
				get
				{
					return this.result.AppID;
				}
				set
				{
					this.SetAppID(value);
				}
			}

			public string SdkVersion
			{
				get
				{
					return this.result.SdkVersion;
				}
				set
				{
					this.SetSdkVersion(value);
				}
			}

			public string CheckContent
			{
				get
				{
					return this.result.CheckContent;
				}
				set
				{
					this.SetCheckContent(value);
				}
			}

			public string CheckSummary
			{
				get
				{
					return this.result.CheckSummary;
				}
				set
				{
					this.SetCheckSummary(value);
				}
			}

			public GetMessageFromWXReq GetReq
			{
				get
				{
					return this.result.GetReq;
				}
				set
				{
					this.SetGetReq(value);
				}
			}

			public SendAuthReq AuthReq
			{
				get
				{
					return this.result.AuthReq;
				}
				set
				{
					this.SetAuthReq(value);
				}
			}

			public SendMessageToWXReq SendReq
			{
				get
				{
					return this.result.SendReq;
				}
				set
				{
					this.SetSendReq(value);
				}
			}

			public ShowMessageFromWXReq ShowReq
			{
				get
				{
					return this.result.ShowReq;
				}
				set
				{
					this.SetShowReq(value);
				}
			}

			public GetMessageFromWXResp GetResp
			{
				get
				{
					return this.result.GetResp;
				}
				set
				{
					this.SetGetResp(value);
				}
			}

			public SendAuthResp AuthResp
			{
				get
				{
					return this.result.AuthResp;
				}
				set
				{
					this.SetAuthResp(value);
				}
			}

			public SendMessageToWXResp SendResp
			{
				get
				{
					return this.result.SendResp;
				}
				set
				{
					this.SetSendResp(value);
				}
			}

			public ShowMessageFromWXResp ShowResp
			{
				get
				{
					return this.result.ShowResp;
				}
				set
				{
					this.SetShowResp(value);
				}
			}

			public SendPayReqP PayReq
			{
				get
				{
					return this.result.PayReq;
				}
				set
				{
					this.SetPayReq(value);
				}
			}

			public SendPayRespP PayResp
			{
				get
				{
					return this.result.PayResp;
				}
				set
				{
					this.SetPayResp(value);
				}
			}

			public Builder()
			{
				this.result = TransactDataP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(TransactDataP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private TransactDataP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					TransactDataP other = this.result;
					this.result = new TransactDataP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override TransactDataP.Builder Clear()
			{
				this.result = TransactDataP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override TransactDataP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new TransactDataP.Builder(this.result);
				}
				return new TransactDataP.Builder().MergeFrom(this.result);
			}

			public override TransactDataP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override TransactDataP.Builder MergeFrom(IMessageLite other)
			{
				if (other is TransactDataP)
				{
					return this.MergeFrom((TransactDataP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override TransactDataP.Builder MergeFrom(TransactDataP other)
			{
				return this;
			}

			public override TransactDataP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override TransactDataP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(TransactDataP._transactDataPFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = TransactDataP._transactDataPFieldTags[num2];
					}
					uint num3 = num;
					if (num3 <= 58u)
					{
						if (num3 <= 26u)
						{
							if (num3 <= 8u)
							{
								if (num3 == 0u)
								{
									throw InvalidProtocolBufferException.InvalidTag();
								}
								if (num3 == 8u)
								{
									this.result.hasConmandID = input.ReadUInt32(ref this.result.conmandID_);
									continue;
								}
							}
							else
							{
								if (num3 == 18u)
								{
									this.result.hasAppID = input.ReadString(ref this.result.appID_);
									continue;
								}
								if (num3 == 26u)
								{
									this.result.hasSdkVersion = input.ReadString(ref this.result.sdkVersion_);
									continue;
								}
							}
						}
						else if (num3 <= 42u)
						{
							if (num3 == 34u)
							{
								this.result.hasCheckContent = input.ReadString(ref this.result.checkContent_);
								continue;
							}
							if (num3 == 42u)
							{
								this.result.hasCheckSummary = input.ReadString(ref this.result.checkSummary_);
								continue;
							}
						}
						else
						{
							if (num3 == 50u)
							{
								GetMessageFromWXReq.Builder builder = GetMessageFromWXReq.CreateBuilder();
								if (this.result.hasGetReq)
								{
									builder.MergeFrom(this.GetReq);
								}
								input.ReadMessage(builder, extensionRegistry);
								this.GetReq = builder.BuildPartial();
								continue;
							}
							if (num3 == 58u)
							{
								SendAuthReq.Builder builder2 = SendAuthReq.CreateBuilder();
								if (this.result.hasAuthReq)
								{
									builder2.MergeFrom(this.AuthReq);
								}
								input.ReadMessage(builder2, extensionRegistry);
								this.AuthReq = builder2.BuildPartial();
								continue;
							}
						}
					}
					else if (num3 <= 90u)
					{
						if (num3 <= 74u)
						{
							if (num3 == 66u)
							{
								SendMessageToWXReq.Builder builder3 = SendMessageToWXReq.CreateBuilder();
								if (this.result.hasSendReq)
								{
									builder3.MergeFrom(this.SendReq);
								}
								input.ReadMessage(builder3, extensionRegistry);
								this.SendReq = builder3.BuildPartial();
								continue;
							}
							if (num3 == 74u)
							{
								ShowMessageFromWXReq.Builder builder4 = ShowMessageFromWXReq.CreateBuilder();
								if (this.result.hasShowReq)
								{
									builder4.MergeFrom(this.ShowReq);
								}
								input.ReadMessage(builder4, extensionRegistry);
								this.ShowReq = builder4.BuildPartial();
								continue;
							}
						}
						else
						{
							if (num3 == 82u)
							{
								GetMessageFromWXResp.Builder builder5 = GetMessageFromWXResp.CreateBuilder();
								if (this.result.hasGetResp)
								{
									builder5.MergeFrom(this.GetResp);
								}
								input.ReadMessage(builder5, extensionRegistry);
								this.GetResp = builder5.BuildPartial();
								continue;
							}
							if (num3 == 90u)
							{
								SendAuthResp.Builder builder6 = SendAuthResp.CreateBuilder();
								if (this.result.hasAuthResp)
								{
									builder6.MergeFrom(this.AuthResp);
								}
								input.ReadMessage(builder6, extensionRegistry);
								this.AuthResp = builder6.BuildPartial();
								continue;
							}
						}
					}
					else if (num3 <= 106u)
					{
						if (num3 == 98u)
						{
							SendMessageToWXResp.Builder builder7 = SendMessageToWXResp.CreateBuilder();
							if (this.result.hasSendResp)
							{
								builder7.MergeFrom(this.SendResp);
							}
							input.ReadMessage(builder7, extensionRegistry);
							this.SendResp = builder7.BuildPartial();
							continue;
						}
						if (num3 == 106u)
						{
							ShowMessageFromWXResp.Builder builder8 = ShowMessageFromWXResp.CreateBuilder();
							if (this.result.hasShowResp)
							{
								builder8.MergeFrom(this.ShowResp);
							}
							input.ReadMessage(builder8, extensionRegistry);
							this.ShowResp = builder8.BuildPartial();
							continue;
						}
					}
					else
					{
						if (num3 == 114u)
						{
							SendPayReqP.Builder builder9 = SendPayReqP.CreateBuilder();
							if (this.result.hasPayReq)
							{
								builder9.MergeFrom(this.PayReq);
							}
							input.ReadMessage(builder9, extensionRegistry);
							this.PayReq = builder9.BuildPartial();
							continue;
						}
						if (num3 == 122u)
						{
							SendPayRespP.Builder builder10 = SendPayRespP.CreateBuilder();
							if (this.result.hasPayResp)
							{
								builder10.MergeFrom(this.PayResp);
							}
							input.ReadMessage(builder10, extensionRegistry);
							this.PayResp = builder10.BuildPartial();
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

			public TransactDataP.Builder SetConmandID(uint value)
			{
				this.PrepareBuilder();
				this.result.hasConmandID = true;
				this.result.conmandID_ = value;
				return this;
			}

			public TransactDataP.Builder ClearConmandID()
			{
				this.PrepareBuilder();
				this.result.hasConmandID = false;
				this.result.conmandID_ = 0u;
				return this;
			}

			public TransactDataP.Builder SetAppID(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAppID = true;
				this.result.appID_ = value;
				return this;
			}

			public TransactDataP.Builder ClearAppID()
			{
				this.PrepareBuilder();
				this.result.hasAppID = false;
				this.result.appID_ = "";
				return this;
			}

			public TransactDataP.Builder SetSdkVersion(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasSdkVersion = true;
				this.result.sdkVersion_ = value;
				return this;
			}

			public TransactDataP.Builder ClearSdkVersion()
			{
				this.PrepareBuilder();
				this.result.hasSdkVersion = false;
				this.result.sdkVersion_ = "";
				return this;
			}

			public TransactDataP.Builder SetCheckContent(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasCheckContent = true;
				this.result.checkContent_ = value;
				return this;
			}

			public TransactDataP.Builder ClearCheckContent()
			{
				this.PrepareBuilder();
				this.result.hasCheckContent = false;
				this.result.checkContent_ = "";
				return this;
			}

			public TransactDataP.Builder SetCheckSummary(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasCheckSummary = true;
				this.result.checkSummary_ = value;
				return this;
			}

			public TransactDataP.Builder ClearCheckSummary()
			{
				this.PrepareBuilder();
				this.result.hasCheckSummary = false;
				this.result.checkSummary_ = "";
				return this;
			}

			public TransactDataP.Builder SetGetReq(GetMessageFromWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasGetReq = true;
				this.result.getReq_ = value;
				return this;
			}

			public TransactDataP.Builder SetGetReq(GetMessageFromWXReq.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasGetReq = true;
				this.result.getReq_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeGetReq(GetMessageFromWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasGetReq && this.result.getReq_ != GetMessageFromWXReq.DefaultInstance)
				{
					this.result.getReq_ = GetMessageFromWXReq.CreateBuilder(this.result.getReq_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.getReq_ = value;
				}
				this.result.hasGetReq = true;
				return this;
			}

			public TransactDataP.Builder ClearGetReq()
			{
				this.PrepareBuilder();
				this.result.hasGetReq = false;
				this.result.getReq_ = null;
				return this;
			}

			public TransactDataP.Builder SetAuthReq(SendAuthReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAuthReq = true;
				this.result.authReq_ = value;
				return this;
			}

			public TransactDataP.Builder SetAuthReq(SendAuthReq.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasAuthReq = true;
				this.result.authReq_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeAuthReq(SendAuthReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasAuthReq && this.result.authReq_ != SendAuthReq.DefaultInstance)
				{
					this.result.authReq_ = SendAuthReq.CreateBuilder(this.result.authReq_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.authReq_ = value;
				}
				this.result.hasAuthReq = true;
				return this;
			}

			public TransactDataP.Builder ClearAuthReq()
			{
				this.PrepareBuilder();
				this.result.hasAuthReq = false;
				this.result.authReq_ = null;
				return this;
			}

			public TransactDataP.Builder SetSendReq(SendMessageToWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasSendReq = true;
				this.result.sendReq_ = value;
				return this;
			}

			public TransactDataP.Builder SetSendReq(SendMessageToWXReq.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasSendReq = true;
				this.result.sendReq_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeSendReq(SendMessageToWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasSendReq && this.result.sendReq_ != SendMessageToWXReq.DefaultInstance)
				{
					this.result.sendReq_ = SendMessageToWXReq.CreateBuilder(this.result.sendReq_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.sendReq_ = value;
				}
				this.result.hasSendReq = true;
				return this;
			}

			public TransactDataP.Builder ClearSendReq()
			{
				this.PrepareBuilder();
				this.result.hasSendReq = false;
				this.result.sendReq_ = null;
				return this;
			}

			public TransactDataP.Builder SetShowReq(ShowMessageFromWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasShowReq = true;
				this.result.showReq_ = value;
				return this;
			}

			public TransactDataP.Builder SetShowReq(ShowMessageFromWXReq.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasShowReq = true;
				this.result.showReq_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeShowReq(ShowMessageFromWXReq value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasShowReq && this.result.showReq_ != ShowMessageFromWXReq.DefaultInstance)
				{
					this.result.showReq_ = ShowMessageFromWXReq.CreateBuilder(this.result.showReq_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.showReq_ = value;
				}
				this.result.hasShowReq = true;
				return this;
			}

			public TransactDataP.Builder ClearShowReq()
			{
				this.PrepareBuilder();
				this.result.hasShowReq = false;
				this.result.showReq_ = null;
				return this;
			}

			public TransactDataP.Builder SetGetResp(GetMessageFromWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasGetResp = true;
				this.result.getResp_ = value;
				return this;
			}

			public TransactDataP.Builder SetGetResp(GetMessageFromWXResp.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasGetResp = true;
				this.result.getResp_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeGetResp(GetMessageFromWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasGetResp && this.result.getResp_ != GetMessageFromWXResp.DefaultInstance)
				{
					this.result.getResp_ = GetMessageFromWXResp.CreateBuilder(this.result.getResp_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.getResp_ = value;
				}
				this.result.hasGetResp = true;
				return this;
			}

			public TransactDataP.Builder ClearGetResp()
			{
				this.PrepareBuilder();
				this.result.hasGetResp = false;
				this.result.getResp_ = null;
				return this;
			}

			public TransactDataP.Builder SetAuthResp(SendAuthResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasAuthResp = true;
				this.result.authResp_ = value;
				return this;
			}

			public TransactDataP.Builder SetAuthResp(SendAuthResp.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasAuthResp = true;
				this.result.authResp_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeAuthResp(SendAuthResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasAuthResp && this.result.authResp_ != SendAuthResp.DefaultInstance)
				{
					this.result.authResp_ = SendAuthResp.CreateBuilder(this.result.authResp_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.authResp_ = value;
				}
				this.result.hasAuthResp = true;
				return this;
			}

			public TransactDataP.Builder ClearAuthResp()
			{
				this.PrepareBuilder();
				this.result.hasAuthResp = false;
				this.result.authResp_ = null;
				return this;
			}

			public TransactDataP.Builder SetSendResp(SendMessageToWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasSendResp = true;
				this.result.sendResp_ = value;
				return this;
			}

			public TransactDataP.Builder SetSendResp(SendMessageToWXResp.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasSendResp = true;
				this.result.sendResp_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeSendResp(SendMessageToWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasSendResp && this.result.sendResp_ != SendMessageToWXResp.DefaultInstance)
				{
					this.result.sendResp_ = SendMessageToWXResp.CreateBuilder(this.result.sendResp_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.sendResp_ = value;
				}
				this.result.hasSendResp = true;
				return this;
			}

			public TransactDataP.Builder ClearSendResp()
			{
				this.PrepareBuilder();
				this.result.hasSendResp = false;
				this.result.sendResp_ = null;
				return this;
			}

			public TransactDataP.Builder SetShowResp(ShowMessageFromWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasShowResp = true;
				this.result.showResp_ = value;
				return this;
			}

			public TransactDataP.Builder SetShowResp(ShowMessageFromWXResp.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasShowResp = true;
				this.result.showResp_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergeShowResp(ShowMessageFromWXResp value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasShowResp && this.result.showResp_ != ShowMessageFromWXResp.DefaultInstance)
				{
					this.result.showResp_ = ShowMessageFromWXResp.CreateBuilder(this.result.showResp_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.showResp_ = value;
				}
				this.result.hasShowResp = true;
				return this;
			}

			public TransactDataP.Builder ClearShowResp()
			{
				this.PrepareBuilder();
				this.result.hasShowResp = false;
				this.result.showResp_ = null;
				return this;
			}

			public TransactDataP.Builder SetPayReq(SendPayReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPayReq = true;
				this.result.payReq_ = value;
				return this;
			}

			public TransactDataP.Builder SetPayReq(SendPayReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasPayReq = true;
				this.result.payReq_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergePayReq(SendPayReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasPayReq && this.result.payReq_ != SendPayReqP.DefaultInstance)
				{
					this.result.payReq_ = SendPayReqP.CreateBuilder(this.result.payReq_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.payReq_ = value;
				}
				this.result.hasPayReq = true;
				return this;
			}

			public TransactDataP.Builder ClearPayReq()
			{
				this.PrepareBuilder();
				this.result.hasPayReq = false;
				this.result.payReq_ = null;
				return this;
			}

			public TransactDataP.Builder SetPayResp(SendPayRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPayResp = true;
				this.result.payResp_ = value;
				return this;
			}

			public TransactDataP.Builder SetPayResp(SendPayRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasPayResp = true;
				this.result.payResp_ = builderForValue.Build();
				return this;
			}

			public TransactDataP.Builder MergePayResp(SendPayRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasPayResp && this.result.payResp_ != SendPayRespP.DefaultInstance)
				{
					this.result.payResp_ = SendPayRespP.CreateBuilder(this.result.payResp_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.payResp_ = value;
				}
				this.result.hasPayResp = true;
				return this;
			}

			public TransactDataP.Builder ClearPayResp()
			{
				this.PrepareBuilder();
				this.result.hasPayResp = false;
				this.result.payResp_ = null;
				return this;
			}
		}

		public const int ConmandIDFieldNumber = 1;

		public const int AppIDFieldNumber = 2;

		public const int SdkVersionFieldNumber = 3;

		public const int CheckContentFieldNumber = 4;

		public const int CheckSummaryFieldNumber = 5;

		public const int GetReqFieldNumber = 6;

		public const int AuthReqFieldNumber = 7;

		public const int SendReqFieldNumber = 8;

		public const int ShowReqFieldNumber = 9;

		public const int GetRespFieldNumber = 10;

		public const int AuthRespFieldNumber = 11;

		public const int SendRespFieldNumber = 12;

		public const int ShowRespFieldNumber = 13;

		public const int PayReqFieldNumber = 14;

		public const int PayRespFieldNumber = 15;

		private static readonly TransactDataP defaultInstance;

		private static readonly string[] _transactDataPFieldNames;

		private static readonly uint[] _transactDataPFieldTags;

		private bool hasConmandID;

		private uint conmandID_;

		private bool hasAppID;

		private string appID_ = "";

		private bool hasSdkVersion;

		private string sdkVersion_ = "";

		private bool hasCheckContent;

		private string checkContent_ = "";

		private bool hasCheckSummary;

		private string checkSummary_ = "";

		private bool hasGetReq;

		private GetMessageFromWXReq getReq_;

		private bool hasAuthReq;

		private SendAuthReq authReq_;

		private bool hasSendReq;

		private SendMessageToWXReq sendReq_;

		private bool hasShowReq;

		private ShowMessageFromWXReq showReq_;

		private bool hasGetResp;

		private GetMessageFromWXResp getResp_;

		private bool hasAuthResp;

		private SendAuthResp authResp_;

		private bool hasSendResp;

		private SendMessageToWXResp sendResp_;

		private bool hasShowResp;

		private ShowMessageFromWXResp showResp_;

		private bool hasPayReq;

		private SendPayReqP payReq_;

		private bool hasPayResp;

		private SendPayRespP payResp_;

		private int memoizedSerializedSize = -1;

		public static TransactDataP DefaultInstance
		{
			get
			{
				return TransactDataP.defaultInstance;
			}
		}

		public override TransactDataP DefaultInstanceForType
		{
			get
			{
				return TransactDataP.DefaultInstance;
			}
		}

		protected override TransactDataP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public uint ConmandID
		{
			get
			{
				return this.conmandID_;
			}
		}

		public string AppID
		{
			get
			{
				return this.appID_;
			}
		}

		public string SdkVersion
		{
			get
			{
				return this.sdkVersion_;
			}
		}

		public string CheckContent
		{
			get
			{
				return this.checkContent_;
			}
		}

		public string CheckSummary
		{
			get
			{
				return this.checkSummary_;
			}
		}

		public GetMessageFromWXReq GetReq
		{
			get
			{
				return this.getReq_ ?? GetMessageFromWXReq.DefaultInstance;
			}
		}

		public SendAuthReq AuthReq
		{
			get
			{
				return this.authReq_ ?? SendAuthReq.DefaultInstance;
			}
		}

		public SendMessageToWXReq SendReq
		{
			get
			{
				return this.sendReq_ ?? SendMessageToWXReq.DefaultInstance;
			}
		}

		public ShowMessageFromWXReq ShowReq
		{
			get
			{
				return this.showReq_ ?? ShowMessageFromWXReq.DefaultInstance;
			}
		}

		public GetMessageFromWXResp GetResp
		{
			get
			{
				return this.getResp_ ?? GetMessageFromWXResp.DefaultInstance;
			}
		}

		public SendAuthResp AuthResp
		{
			get
			{
				return this.authResp_ ?? SendAuthResp.DefaultInstance;
			}
		}

		public SendMessageToWXResp SendResp
		{
			get
			{
				return this.sendResp_ ?? SendMessageToWXResp.DefaultInstance;
			}
		}

		public ShowMessageFromWXResp ShowResp
		{
			get
			{
				return this.showResp_ ?? ShowMessageFromWXResp.DefaultInstance;
			}
		}

		public SendPayReqP PayReq
		{
			get
			{
				return this.payReq_ ?? SendPayReqP.DefaultInstance;
			}
		}

		public SendPayRespP PayResp
		{
			get
			{
				return this.payResp_ ?? SendPayRespP.DefaultInstance;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasConmandID && this.hasAppID && this.hasSdkVersion && this.hasCheckContent && this.hasCheckSummary;
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
				if (this.hasConmandID)
				{
					num += CodedOutputStream.ComputeUInt32Size(1, this.ConmandID);
				}
				if (this.hasAppID)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.AppID);
				}
				if (this.hasSdkVersion)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.SdkVersion);
				}
				if (this.hasCheckContent)
				{
					num += CodedOutputStream.ComputeStringSize(4, this.CheckContent);
				}
				if (this.hasCheckSummary)
				{
					num += CodedOutputStream.ComputeStringSize(5, this.CheckSummary);
				}
				if (this.hasGetReq)
				{
					num += CodedOutputStream.ComputeMessageSize(6, this.GetReq);
				}
				if (this.hasAuthReq)
				{
					num += CodedOutputStream.ComputeMessageSize(7, this.AuthReq);
				}
				if (this.hasSendReq)
				{
					num += CodedOutputStream.ComputeMessageSize(8, this.SendReq);
				}
				if (this.hasShowReq)
				{
					num += CodedOutputStream.ComputeMessageSize(9, this.ShowReq);
				}
				if (this.hasGetResp)
				{
					num += CodedOutputStream.ComputeMessageSize(10, this.GetResp);
				}
				if (this.hasAuthResp)
				{
					num += CodedOutputStream.ComputeMessageSize(11, this.AuthResp);
				}
				if (this.hasSendResp)
				{
					num += CodedOutputStream.ComputeMessageSize(12, this.SendResp);
				}
				if (this.hasShowResp)
				{
					num += CodedOutputStream.ComputeMessageSize(13, this.ShowResp);
				}
				if (this.hasPayReq)
				{
					num += CodedOutputStream.ComputeMessageSize(14, this.PayReq);
				}
				if (this.hasPayResp)
				{
					num += CodedOutputStream.ComputeMessageSize(15, this.PayResp);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private TransactDataP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] transactDataPFieldNames = TransactDataP._transactDataPFieldNames;
			if (this.hasConmandID)
			{
				output.WriteUInt32(1, transactDataPFieldNames[5], this.ConmandID);
			}
			if (this.hasAppID)
			{
				output.WriteString(2, transactDataPFieldNames[0], this.AppID);
			}
			if (this.hasSdkVersion)
			{
				output.WriteString(3, transactDataPFieldNames[10], this.SdkVersion);
			}
			if (this.hasCheckContent)
			{
				output.WriteString(4, transactDataPFieldNames[3], this.CheckContent);
			}
			if (this.hasCheckSummary)
			{
				output.WriteString(5, transactDataPFieldNames[4], this.CheckSummary);
			}
			if (this.hasGetReq)
			{
				output.WriteMessage(6, transactDataPFieldNames[6], this.GetReq);
			}
			if (this.hasAuthReq)
			{
				output.WriteMessage(7, transactDataPFieldNames[1], this.AuthReq);
			}
			if (this.hasSendReq)
			{
				output.WriteMessage(8, transactDataPFieldNames[11], this.SendReq);
			}
			if (this.hasShowReq)
			{
				output.WriteMessage(9, transactDataPFieldNames[13], this.ShowReq);
			}
			if (this.hasGetResp)
			{
				output.WriteMessage(10, transactDataPFieldNames[7], this.GetResp);
			}
			if (this.hasAuthResp)
			{
				output.WriteMessage(11, transactDataPFieldNames[2], this.AuthResp);
			}
			if (this.hasSendResp)
			{
				output.WriteMessage(12, transactDataPFieldNames[12], this.SendResp);
			}
			if (this.hasShowResp)
			{
				output.WriteMessage(13, transactDataPFieldNames[14], this.ShowResp);
			}
			if (this.hasPayReq)
			{
				output.WriteMessage(14, transactDataPFieldNames[8], this.PayReq);
			}
			if (this.hasPayResp)
			{
				output.WriteMessage(15, transactDataPFieldNames[9], this.PayResp);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasConmandID)
			{
				num ^= this.conmandID_.GetHashCode();
			}
			if (this.hasAppID)
			{
				num ^= this.appID_.GetHashCode();
			}
			if (this.hasSdkVersion)
			{
				num ^= this.sdkVersion_.GetHashCode();
			}
			if (this.hasCheckContent)
			{
				num ^= this.checkContent_.GetHashCode();
			}
			if (this.hasCheckSummary)
			{
				num ^= this.checkSummary_.GetHashCode();
			}
			if (this.hasGetReq)
			{
				num ^= this.getReq_.GetHashCode();
			}
			if (this.hasAuthReq)
			{
				num ^= this.authReq_.GetHashCode();
			}
			if (this.hasSendReq)
			{
				num ^= this.sendReq_.GetHashCode();
			}
			if (this.hasShowReq)
			{
				num ^= this.showReq_.GetHashCode();
			}
			if (this.hasGetResp)
			{
				num ^= this.getResp_.GetHashCode();
			}
			if (this.hasAuthResp)
			{
				num ^= this.authResp_.GetHashCode();
			}
			if (this.hasSendResp)
			{
				num ^= this.sendResp_.GetHashCode();
			}
			if (this.hasShowResp)
			{
				num ^= this.showResp_.GetHashCode();
			}
			if (this.hasPayReq)
			{
				num ^= this.payReq_.GetHashCode();
			}
			if (this.hasPayResp)
			{
				num ^= this.payResp_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			TransactDataP transactDataP = obj as TransactDataP;
			return transactDataP != null && this.hasConmandID == transactDataP.hasConmandID && (!this.hasConmandID || this.conmandID_.Equals(transactDataP.conmandID_)) && this.hasAppID == transactDataP.hasAppID && (!this.hasAppID || this.appID_.Equals(transactDataP.appID_)) && this.hasSdkVersion == transactDataP.hasSdkVersion && (!this.hasSdkVersion || this.sdkVersion_.Equals(transactDataP.sdkVersion_)) && this.hasCheckContent == transactDataP.hasCheckContent && (!this.hasCheckContent || this.checkContent_.Equals(transactDataP.checkContent_)) && this.hasCheckSummary == transactDataP.hasCheckSummary && (!this.hasCheckSummary || this.checkSummary_.Equals(transactDataP.checkSummary_)) && this.hasGetReq == transactDataP.hasGetReq && (!this.hasGetReq || this.getReq_.Equals(transactDataP.getReq_)) && this.hasAuthReq == transactDataP.hasAuthReq && (!this.hasAuthReq || this.authReq_.Equals(transactDataP.authReq_)) && this.hasSendReq == transactDataP.hasSendReq && (!this.hasSendReq || this.sendReq_.Equals(transactDataP.sendReq_)) && this.hasShowReq == transactDataP.hasShowReq && (!this.hasShowReq || this.showReq_.Equals(transactDataP.showReq_)) && this.hasGetResp == transactDataP.hasGetResp && (!this.hasGetResp || this.getResp_.Equals(transactDataP.getResp_)) && this.hasAuthResp == transactDataP.hasAuthResp && (!this.hasAuthResp || this.authResp_.Equals(transactDataP.authResp_)) && this.hasSendResp == transactDataP.hasSendResp && (!this.hasSendResp || this.sendResp_.Equals(transactDataP.sendResp_)) && this.hasShowResp == transactDataP.hasShowResp && (!this.hasShowResp || this.showResp_.Equals(transactDataP.showResp_)) && this.hasPayReq == transactDataP.hasPayReq && (!this.hasPayReq || this.payReq_.Equals(transactDataP.payReq_)) && this.hasPayResp == transactDataP.hasPayResp && (!this.hasPayResp || this.payResp_.Equals(transactDataP.payResp_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("ConmandID", this.hasConmandID, this.conmandID_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("AppID", this.hasAppID, this.appID_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("SdkVersion", this.hasSdkVersion, this.sdkVersion_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("CheckContent", this.hasCheckContent, this.checkContent_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("CheckSummary", this.hasCheckSummary, this.checkSummary_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("GetReq", this.hasGetReq, this.getReq_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("AuthReq", this.hasAuthReq, this.authReq_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("SendReq", this.hasSendReq, this.sendReq_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("ShowReq", this.hasShowReq, this.showReq_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("GetResp", this.hasGetResp, this.getResp_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("AuthResp", this.hasAuthResp, this.authResp_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("SendResp", this.hasSendResp, this.sendResp_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("ShowResp", this.hasShowResp, this.showResp_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("PayReq", this.hasPayReq, this.payReq_, writer);
			GeneratedMessageLite<TransactDataP, TransactDataP.Builder>.PrintField("PayResp", this.hasPayResp, this.payResp_, writer);
		}

		public static TransactDataP ParseFrom(byte[] data)
		{
			return TransactDataP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private TransactDataP MakeReadOnly()
		{
			return this;
		}

		public static TransactDataP.Builder CreateBuilder()
		{
			return new TransactDataP.Builder();
		}

		public override TransactDataP.Builder ToBuilder()
		{
			return TransactDataP.CreateBuilder(this);
		}

		public override TransactDataP.Builder CreateBuilderForType()
		{
			return new TransactDataP.Builder();
		}

		public static TransactDataP.Builder CreateBuilder(TransactDataP prototype)
		{
			return new TransactDataP.Builder(prototype);
		}

		static TransactDataP()
		{
			TransactDataP.defaultInstance = new TransactDataP().MakeReadOnly();
			TransactDataP._transactDataPFieldNames = new string[]
			{
				"AppID",
				"AuthReq",
				"AuthResp",
				"CheckContent",
				"CheckSummary",
				"ConmandID",
				"GetReq",
				"GetResp",
				"PayReq",
				"PayResp",
				"SdkVersion",
				"SendReq",
				"SendResp",
				"ShowReq",
				"ShowResp"
			};
			TransactDataP._transactDataPFieldTags = new uint[]
			{
				18u,
				58u,
				90u,
				34u,
				42u,
				8u,
				50u,
				82u,
				114u,
				122u,
				26u,
				66u,
				98u,
				74u,
				106u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.TransactDataP.Descriptor, null);
		}
	}
}
