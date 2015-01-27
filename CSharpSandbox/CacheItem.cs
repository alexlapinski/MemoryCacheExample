namespace CSharpSandbox
{
	using System;

	public sealed class CacheItem<T> 
	{
		public T Value {get; set;}
		public Func<T> Fetcher {get; set;}
	}
}