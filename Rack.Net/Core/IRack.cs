using System.Collections.Generic;

namespace Rack.Net.Core
{
	public interface IRack
	{
		IResponse Call(IDictionary<string, object> data);
	}
}