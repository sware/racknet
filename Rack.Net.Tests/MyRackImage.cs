using System.Collections.Generic;
using System.IO;

namespace Rack.Net.Tests
{
	public class MyRackImage : IRack
	{
		#region IApplication Members

		public IResponse Call(IDictionary<string, object> data)
		{
			return new Response(Response.StatusCode.OK, Response.StandardHeader.HTML, File.ReadAllBytes("rack.gif"));
		}

		#endregion
	}
}