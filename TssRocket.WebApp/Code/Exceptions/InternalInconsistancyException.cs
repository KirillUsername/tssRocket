using System;

namespace TssRocket.WebApp.Code.Exceptions
{
	public class InternalInconsistancyException
		: Exception
	{
		public InternalInconsistancyException(string exception)
			: base(exception)
		{

		}
	}
}
