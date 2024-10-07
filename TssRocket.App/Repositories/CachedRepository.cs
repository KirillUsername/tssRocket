using Microsoft.Extensions.Caching.Memory;
using TssRocket.App.Repositories;

namespace TssRocket.Domain.Repository
{
	public abstract class CachedRepository(IMemoryCache memoryCache)
	{
		private static readonly object _loadLockObject = new();

		private object? _cachedData;

		protected abstract string CacheKey { get; }

		protected T GetCachedData<T>()
		{
			if (_cachedData is not null)
			{
				return (T)_cachedData;
			}

			var cacheHelper = new MemoryCacheHelper(
				cacheKey: CacheKey,
				memoryCache: memoryCache,
				lockObject: _loadLockObject
			);

			_cachedData = cacheHelper.GetInstance(LoadData);

			return (T)_cachedData;
		}

		protected abstract (object instance, bool isSliding, TimeSpan timeout) LoadData();
	}
}
