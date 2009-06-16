using System.Collections.Generic;
using System;

namespace Rack.Net.Tests
{
	public class MammogramRack : IRack
	{
		#region IRack Members

		public IResponse Call(IDictionary<string, object> environment)
		{
			return new Response(Response.StatusCode.OK, Response.StandardHeader.HTML,
				String.Format("<TABLE BORDER=1>{0}</TABLE>", DicationaryWriter.Write(environment,
																		(k, v) => string.Format("<TR><TD>{0}</TD><TD>{1}</TD></TR>", k, v))));
		}

		#endregion
	}
}