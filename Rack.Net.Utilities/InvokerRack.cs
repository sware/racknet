using System;
using System.Collections.Generic;
using Rack.Net.Core;
using Rack.Net.Core.Common;

namespace Rack.Net.Utilities
{
	public class InvokerRack : IRack
	{
		public IResponse Call(IDictionary<string, object> data)
		{

			string className = ((string[])data[RackHeader.URI])[0];
			
			className = className.Substring(className.LastIndexOf('/')+1);
			className = className + ", " + className.Substring(0, className.LastIndexOf('.'));
			Type rackClass = Type.GetType(className);
			return ((IRack) Activator.CreateInstance(rackClass)).Call(data);
		}
	}
	public class RackHeader
	{
		public const string URI = "PATH_INFO";
	}
}