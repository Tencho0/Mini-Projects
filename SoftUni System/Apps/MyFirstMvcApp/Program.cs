using SoftUniSystem.HTTP;
using MyFirstMvcApp.Controllers;

namespace MyFirstMvcApp;

public class Program
{
    static async Task Main(string[] args)
    {
        IHttpServer server = new HttpServer();

        server.AddRoute("/", new HomeController().Index);
        server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
        server.AddRoute("/about", new HomeController().About);
        server.AddRoute("/users/login", new UserController().Login);
        server.AddRoute("/users/register", new UserController().Register);

        await server.StartAsync(80);
    }
}