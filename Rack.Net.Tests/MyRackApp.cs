using System.Collections.Generic;

namespace Rack.Net.Tests
{
	public class MyRackApp : IRack
	{
		#region IApplication Members

		public IResponse Call(IDictionary<string, object> data)
		{
			return new Response(Response.StatusCode.OK, Response.StandardHeader.HTML, "Nice rack! (*)(*)");
		}

		#endregion
	}
}