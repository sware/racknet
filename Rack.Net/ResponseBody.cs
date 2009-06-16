using System.Text;

namespace Rack.Net
{
	public class ResponseBody
	{
		private readonly byte[] bodyAsBytes;
		private readonly string stringBody;

		public ResponseBody(string body)
		{
			stringBody = body;
		}

		public ResponseBody(byte[] body)
		{
			bodyAsBytes = body;
		}

		public byte[] ToBytes()
		{
			if (IsString())
				return Encoding.UTF8.GetBytes(stringBody);
			return bodyAsBytes;
		}

		public bool IsString()
		{
			return stringBody != null;
		}

		public override string ToString()
		{
			return stringBody;
		}
	}
}