using MediatR;
using TssRocket.App.MediatR.Request;
using TssRocket.App.MediatR.Response;
using TssRocket.Domain.Repository;

namespace TssRocket.App.MediatR.Handler
{
	public class FakeMediatorQueryHandler(ISomeFakeRepository repo)
		: IRequestHandler<FakeMediatorRequest, IFakeMediatorResult>
	{
		private IFakeMediatorResult HandleInternal(FakeMediatorRequest request)
		{
			return new FakeMediatorSuccessResult(repo.GetSomeFakeData());
		}

		public Task<IFakeMediatorResult> Handle(FakeMediatorRequest request, CancellationToken cancellationToken)
		{
			var result = HandleInternal(request);
			return Task.FromResult(result);
		}
	}
}
