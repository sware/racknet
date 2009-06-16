using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using Rack.Net.Tests;

namespace AspAdapter
{

public class RackHandler : IHttpHandler
{
	public void ProcessRequest(HttpContext context)
	{
		context.Response.Output.Write(new MammogramRack().Call(ConvertToDicationary(context.Request.Params)).Body);
	}

	public bool IsReusable
	{
		get { return true; }
	}

	private IDictionary<string, object> ConvertToDicationary(NameValueCollection collection)
	{
		Dictionary<string, object> d = new Dictionary<string, object>();

		foreach (string key in collection.Keys)
		{
			d.Add(key, collection.GetValues(key));
		}

		return d;
	}

	
}
}
