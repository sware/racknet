using System.Collections.Generic;

namespace Rack.Net.Core.Common
{
	public class Response : IResponse
	{
		public Response(int status, IDictionary<string, string> headers, byte[] body)
			: this(status, headers, new ResponseBody(body))
		{
			Body = new ResponseBody(body);
			Headers = headers;
			Status = status;
		}

		public Response(int status, IDictionary<string, string> headers, string body)
			: this(status, headers, new ResponseBody(body))
		{
			Headers = headers;
			Status = status;
		}

		public Response(int status, IDictionary<string, string> headers, ResponseBody body)
		{
			Status = status;
			Headers = headers;
			Body = body;
		}

		public int Status { get; set; }
		public IDictionary<string, string> Headers { get; set; }
		public ResponseBody Body { get; set; }

		public static IResponse Html(string html)
		{
			return new Response(StatusCode.OK, StandardHeader.HTML, html);
		}


		public static class StandardHeader
		{
			public static IDictionary<string, string> HTML = new Dictionary<string, string>();
		}


		public static class StatusCode
		{
			public static int OK = 200;
		}
	}
}