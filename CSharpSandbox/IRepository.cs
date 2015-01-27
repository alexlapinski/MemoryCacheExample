namespace CSharpSandbox
{
	public interface IRepository
	{
		string Get(int id);
		string[] GetAll();	
	}
}