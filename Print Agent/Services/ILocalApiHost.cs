namespace Print_Agent.Services
{
	public interface ILocalApiHost : IAsyncDisposable
	{
		Task StartAsync(int port, CancellationToken ct = default);
	}
}
