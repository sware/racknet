using System.Collections.Generic;

namespace Rack.Net
{
	public interface IResponse
	{
		int Status { get; set; }

		IDictionary<string, string> Headers { get; set; }

		ResponseBody Body { get; set; }
	}
}