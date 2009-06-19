using System;
using System.Web;

namespace App_Code
{
	public class RackModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			RackHandler.RackHandleRequest(context.Request,context.Response);
		}

		public void Dispose()
		{
		}
	}
}