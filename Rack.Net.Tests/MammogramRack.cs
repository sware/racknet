using System;
using System.Collections.Generic;
using System.Text;

namespace Rack.Net.Tests
{
	

	public class MammogramRack : IRack
	{
		public IResponse Call(IDictionary<string, object> environment)
		{
			return new Response(Response.StatusCode.OK, Response.StandardHeader.HTML,
			                    String.Format("<TABLE BORDER=1>{0}</TABLE>", DictionaryWriter.Write(environment,
			                                                                                         (k, v) =>
			                                                                                         string.Format(
			                                                                                         	"<TR><TD>{0}</TD><TD>{1}</TD></TR>",
			                                                                                         	k, StringFormat(v)))));
		}

		private string StringFormat(object o)
		{
			if (o is string[])
			{
				return ToString(((String[])o));
			}
			return o.ToString();
		}

		public static string ToString(System.String[] str)
		{
			var sb = new StringBuilder("[");
			foreach (string s in str)
			{
				sb.Append(s + ",");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append("]");
			return sb.ToString();
		}
	}
}