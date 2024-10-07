using Microsoft.Extensions.Caching.Memory;

namespace TssRocket.App.Repositories
{
	public class MemoryCacheHelper(string cacheKey, IMemoryCache memoryCache, object? lockObject = null)
	{
		private readonly object _lockObject = lockObject ?? string.Intern(cacheKey);
		private readonly string _cacheKey = cacheKey ?? throw new ArgumentNullException(nameof(cacheKey));
		private readonly IMemoryCache _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

		public T GetInstance<T>(Func<(T, bool, TimeSpan)> instanceFactory)
		{
			lock (_lockObject)
			{
				if (_memoryCache.TryGetValue<T>(_cacheKey, out var result))
				{
					return result!;
				}

				var (instance, isSliding, timeout) = instanceFactory();

				result = instance;

				var options = new MemoryCacheEntryOptions
				{
					Priority = CacheItemPriority.Normal,
				};
				if (isSliding)
				{
					options.SetSlidingExpiration(timeout);
				}
				else
				{
					options.SetAbsoluteExpiration(timeout);
				}

				_memoryCache.Set(_cacheKey, result, options);

				return result;
			}
		}

		public void ResetCache()
		{
			lock (_lockObject)
			{
				_memoryCache.Remove(_cacheKey);
			}
		}
	}
}
