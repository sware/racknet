using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Web;
using Rack.Net.Core;
using Rack.Net.Tests;

namespace App_Code
{
	public class RackHandler : IHttpHandler
	{
		private static readonly IRack rackApp = LoadMainRackApp();

		private static IRack LoadMainRackApp()
		{
			var className = ConfigurationSettings.AppSettings.GetValues("MainRackApplication")[0];
			var rackClass = System.Type.GetType(className);
			return (IRack) System.Activator.CreateInstance(rackClass);
		}


		public void ProcessRequest(HttpContext context)
		{
			RackHandleRequest(context.Request, context.Response);
		}

		public bool IsReusable
		{
			get { return true; }
		}

		public static void RackHandleRequest(HttpRequest request, HttpResponse response)
		{
			MyRackImage.BasePath = "Rack.Net.Tests/";

			IResponse call = rackApp.Call(ConvertToDicationary(request.Params));
			TransferHeader(response, call.Headers);
			if (call.Body.IsString())
			{
				response.Write(call.Body.ToString());
			}
			else
			{
				response.BinaryWrite(call.Body.ToBytes());
			}
		}

		private static void TransferHeader(HttpResponse to, IDictionary<string, string> from)
		{
			foreach (string k in from.Keys)
			{
				if (from.ContainsKey(k))
				{
					to.AddHeader(k, from[k]);
				}
			}
		}


		private static IDictionary<string, object> ConvertToDicationary(NameValueCollection collection)
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