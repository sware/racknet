using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rack.Net.Core;
using Rack.Net.Tests;

namespace Rack.Net.Utilities.Tests
{
	[TestFixture]
	public class RouterTest
	{
		[Test]
        public static void TestSimpleRoute()
		{
			var app = new MyRackApp();
			Router.Prepare("/MyRackApp", app);
			Assert.AreEqual(app,Router.LookUp("/MyRackApp"));
		}
	}

	public  class Router : IRack
	{
		private static IDictionary<string,IRack> mappings = new Dictionary<string, IRack>();

		public IResponse Call(IDictionary<string, object> data)
		{
			return LookUp("").Call(data);
		}

		public static  IRack LookUp(string url)
		{
			return mappings[url];
		}


		public static void Prepare(string url, IRack app)
		{
			mappings[url] = app;
		}
	}
}