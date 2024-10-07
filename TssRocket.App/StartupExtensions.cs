using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TssRocket.UniGate.Gateway;

namespace TssRocket.App
{
	public static class StartupExtensions
	{
		public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
		{
			var fakeUnigateGateway = new UniGateFakeGateway(new UniGateFakeGateway.SurroateUniGateSettings());
			services.AddSingleton<IUnigateGetway>(fakeUnigateGateway);
		}
	}
}
