using System;
using System.Collections.Generic;
using System.Text;
using Rack.Net.Core;
using Rack.Net.Core.Common;

namespace Rack.Net.Tests
{
	public class MammogramRack : IRack
	{
		public IResponse Call(IDictionary<string, object> environment)
		{
			string env = DictionaryWriter.Write(environment,
			                                    (k, v) =>
			                                    string.Format("<TR><TD>{0}</TD><TD>{1}</TD></TR>", k, StringFormat(v)));
			return Response.Html(String.Format("<TABLE BORDER=1>{0}</TABLE>", env));
		}

		private string StringFormat(object o)
		{
			if (o is string[])
			{
				return ToString(((String[]) o));
			}
			return o.ToString();
		}

		public static string ToString(String[] str)
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