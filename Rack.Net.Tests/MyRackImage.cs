using System.Collections.Generic;
using System.IO;
using Rack.Net.Core;
using Rack.Net.Core.Common;

namespace Rack.Net.Tests
{
	public class MyRackImage : IRack
	{
	public static string BasePath = "" ;
		public IResponse Call(IDictionary<string, object> data)
		{
			var headers = new Dictionary<string, string> { { "Content-Type", "image/gif" } };
			return new Response(Response.StatusCode.OK, headers, File.ReadAllBytes(BasePath + "rack.gif"));
		}
	}
}