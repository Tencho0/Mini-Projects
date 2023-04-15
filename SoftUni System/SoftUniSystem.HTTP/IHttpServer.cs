namespace SoftUniSystem.HTTP;

public interface IHttpServer
{
    Task StartAsync(int port);
}