namespace TssRocket.UniGate.Gateway
{
	public class UniGateFakeGateway
		: IUnigateGetway
	//	: IDisposable
	{

		//private HttpClient _httpClient;

		public UniGateFakeGateway(SurroateUniGateSettings initialSettings)
		{
			//_httpClient = new HttpClient();
		}

		public void MiddleWareTestCall()
		{

		}

		//public void Dispose()
		//{
		//	_httpClient.Dispose();
		//}

		#region nested types
		public struct SurroateUniGateSettings (string openApiKey)
		{
			public readonly string OpenApiKey = openApiKey;
		}

		#endregion

	}
}
