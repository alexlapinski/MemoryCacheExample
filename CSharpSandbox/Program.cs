namespace CSharpSandbox
{
	using System;

	class MainClass
	{
		public static void Main (string[] args)
		{
			var repo = new CachingRepository (10);
			Console.WriteLine ("Getting Item #2");
			var item = repo.Get (2);
			Console.WriteLine ("Value of Item #2: " + item);

			Console.WriteLine ("Getting Item #2");
			item = repo.Get (2);
			Console.WriteLine ("Value of Item #2: " + item);

			Console.WriteLine ("Getting Item #2");
			item = repo.Get (2);
			Console.WriteLine ("Value of Item #2: " + item);
		}
	}
}
