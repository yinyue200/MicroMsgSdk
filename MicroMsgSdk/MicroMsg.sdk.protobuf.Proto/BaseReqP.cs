using Google.ProtocolBuffers;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf.Proto
{
	
	public static class BaseReqP
	{
		internal static readonly object Descriptor;

		public static void RegisterAllExtensions(ExtensionRegistry registry)
		{
		}

		static BaseReqP()
		{
			BaseReqP.Descriptor = null;
		}
	}
}
