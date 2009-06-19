using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using Rack.Net.Tests;


namespace App_Code
{
	
	public class RackHandler : IHttpHandler
	{
		#region IHttpHandler Members

		public void ProcessRequest(HttpContext context)
		{
			context.Response.Output.Write(new MammogramRack().Call(ConvertToDicationary(context.Request.Params)).Body);
		}

		public bool IsReusable
		{
			get { return true; }
		}

		#endregion

		private IDictionary<string, object> ConvertToDicationary(NameValueCollection collection)
		{
			var d = new Dictionary<string, object>();

			foreach (string key in collection.Keys)
			{
				d.Add(key, collection.GetValues(key));
			}

			return d;
		}
	}
}