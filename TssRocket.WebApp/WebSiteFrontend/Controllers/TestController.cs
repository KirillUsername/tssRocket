using MediatR;
using Microsoft.AspNetCore.Mvc;
using TssRocket.App.MediatR.Request;
using TssRocket.App.MediatR.Response;
using TssRocket.WebApp.Code.Exceptions;

namespace TssRocket.WebApp.WebSiteFrontend.Controllers
{
	public class TestController(IMediator mediator)
		: Controller
	{
		[HttpGet]
		public async Task<IActionResult> Test(CancellationToken cancellationToken)
		{
			var query = new FakeMediatorRequest();
			var queryResult = await mediator.Send(query, cancellationToken);

			switch (queryResult)
			{
				case FakeMediatorSuccessResult:
					return Ok();
				case FakeMediatorInvalidResult:
					return BadRequest();
				default:
					throw new InternalInconsistancyException("Some text about incorrect result in TSS. So bad");
			}
		}
	}
}
