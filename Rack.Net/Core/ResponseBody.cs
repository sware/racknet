using System.Text;

namespace Rack.Net.Core
{
	public class ResponseBody
	{
		protected readonly byte[] bodyAsBytes;
		protected readonly string stringBody;

		public ResponseBody(string body)
		{
			stringBody = body;
		}

		public ResponseBody(byte[] body)
		{
			bodyAsBytes = body;
		}

		public virtual byte[] ToBytes()
		{
			if (IsString())
				return Encoding.UTF8.GetBytes(stringBody);
			return bodyAsBytes;
		}

		public virtual bool IsString()
		{
			return stringBody != null;
		}

		public override string ToString()
		{
			return stringBody;
		}
	}
}