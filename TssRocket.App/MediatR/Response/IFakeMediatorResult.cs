namespace TssRocket.App.MediatR.Response
{
	public interface IFakeMediatorResult;
	public class FakeMediatorSuccessResult(object result)
		: IFakeMediatorResult
	{
		public readonly object Result = result;
	}

	public class FakeMediatorInvalidResult
		: IFakeMediatorResult
	{
	}
}
