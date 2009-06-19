using System.Collections.Generic;
using Rack.Net.Core;
using Rack.Net.Core.Common;

namespace Rack.Net.Tests
{
	public class MyRackApp : IRack
	{
		public IResponse Call(IDictionary<string, object> data)
		{
			return Response.Html("Nice rack! (*)(*)");
		}
	}
}