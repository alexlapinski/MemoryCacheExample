namespace CSharpSandbox
{
	using System;
	using System.Linq;
	using System.Threading;
	using System.Runtime.Caching;

	public class CachingRepository : IRepository 
	{
		private TValue Get<TValue>(string key, Func<TValue> fetcher) {
			CacheItem<TValue> cacheItem = (CacheItem<TValue>)cache.Get(key);
			if( cacheItem == null ) {
				Console.WriteLine ("Fetching Item for key: " + key);
				cacheItem = new CacheItem<TValue>{
					Value = fetcher(), 
					Fetcher = fetcher
				};
				cache.Add(key, cacheItem, DateTimeOffset.Now.AddMinutes(cacheDurationInMinutes));
			}
			return cacheItem.Value;
		}

		private readonly int cacheDurationInMinutes;
		private MemoryCache cache;

		public CachingRepository(int cacheDurationInMinutes) {
			this.cacheDurationInMinutes = cacheDurationInMinutes;
			cache = new MemoryCache("CachingRepository");
		}

		public string Get(int id) {
			return Get("item-"+id, ()=> {
				Thread.Sleep(10 * 1000);
				return id.ToString();
			});
		}

		public string[] GetAll() {
			return Get("items", ()=> {
				Thread.Sleep(100 * 1000);
				return Enumerable.Range(1, 100).Select(i=>i.ToString()).ToArray();
			});
		}
	}
}

