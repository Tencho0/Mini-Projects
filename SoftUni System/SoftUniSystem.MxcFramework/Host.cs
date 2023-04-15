using SoftUniSystem.HTTP;

namespace SoftUniSystem.MxcFramework;

public static class Host
{
    public static async Task CreateHostAsync(List<Route> routeTable, int port = 80)
    {
        IHttpServer server = new HttpServer(routeTable);

        await server.StartAsync(port);
    }
}