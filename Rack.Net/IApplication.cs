using System.Collections.Generic;

namespace Rack.Net
{
	public interface IRack
	{
		IResponse Call(IDictionary<string, object> data);
	}
}