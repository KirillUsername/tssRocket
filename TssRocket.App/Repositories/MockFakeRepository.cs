using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace TssRocket.Domain.Repository
{
	public class MockFakeRepository(IServiceScopeFactory serviceScopeFactory, IMemoryCache memoryCache)
		: CachedRepository(memoryCache), ISomeFakeRepository
	{
		protected override string CacheKey => "0CBB9AD2-D35A-4F39-87CD-B5F8103EF4FD";

		public object GetSomeFakeData()
		{
			var cachedContainer = GetCachedData<Container>();
			var random = new Random();
			return cachedContainer.Objs[random.Next(cachedContainer.Objs.Count) - 1];
		}

		// caching data in server memory
		protected override (object instance, bool isSliding, TimeSpan timeout) LoadData()
		{
			using var serviceScope = serviceScopeFactory.CreateScope();
			return (instance: new Container([1, 2, "tss"]) , true, TimeSpan.FromMinutes(30));
		}

		#region nested types

		private class Container(List<object> objs)
		{
			public readonly List<object> Objs = objs;
		}

		#endregion
	}
}
