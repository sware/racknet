using System;
using System.Collections.Generic;
using System.Text;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using NUnit.Framework;

namespace Rack.Net.Tests
{
	[TestFixture]
	public class 
		 Tests
	{
		public void Approve(string html)
		{
			Approvals.Approve(new ApprovalTextWriter(html, "html"), new UnitTestFrameworkNamer(), new OpenReceivedFileReporter());
		}

		public void Approve(byte[] data, string extension)
		{
			Approvals.Approve(new BinaryWriter(data, extension), new UnitTestFrameworkNamer(), new OpenReceivedFileReporter());
		}

		public class HTTPVariables
		{
			public const string REQUEST_METHOD = "REQUEST_METHOD";
			public const string SERVER_NAME = "SERVER_NAME";
			public const string SERVER_PORT = "SERVER_PORT";
		}

		private IDictionary<string, object> GetDemoHTTPEnvironment()
		{
			IDictionary<string, object> environment = new Dictionary<string, object>();
			environment[HTTPVariables.REQUEST_METHOD] = "GET";
			environment[HTTPVariables.SERVER_NAME] = "TOMCAT";
			environment[HTTPVariables.SERVER_PORT] = "8008";
			environment["ALL_HTTP"] = new System.String[]{"a","b"};
			return environment;
		}

		[Test]
		public void TestEnvironment()
		{
			IDictionary<string, object> enviornment = GetDemoHTTPEnvironment();
			Approve(new MammogramRack().Call(enviornment).Body.ToString());
		}

		[Test]
		public void TestImage()
		{
			IDictionary<string, object> environment = new Dictionary<string, object>();
			Approve(new MyRackImage().Call(environment).Body.ToBytes(), "gif");
		}

		[Test]
		public void TestSimpleHtml()
		{
			IDictionary<string, object> environment = new Dictionary<string, object>();
			Approve(new MyRackApp().Call(environment).Body.ToString());
		}

		[Test]
		public void TestStringAsBytes()
		{
			var body = new ResponseBody("byte me");
			Approve(body.ToBytes(), "txt");
		}
	}

	public class DictionaryWriter
	{
		public static string Write(IDictionary<string, object> dicationary, Func<object, object, string> keyValueFormatter)
		{
			var sb = new StringBuilder();
			foreach (var kv in dicationary)
			{
				sb.Append(keyValueFormatter.Invoke(kv.Key, kv.Value));
			}
			return sb.ToString();
		}
	}
}