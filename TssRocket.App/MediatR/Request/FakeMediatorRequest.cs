using MediatR;
using TssRocket.App.MediatR.Response;

namespace TssRocket.App.MediatR.Request
{
	public class FakeMediatorRequest
		: IRequest<IFakeMediatorResult>
	{
	}
}
