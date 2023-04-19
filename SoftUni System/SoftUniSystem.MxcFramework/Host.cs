using SoftUniSystem.HTTP;
using HttpMethod = SoftUniSystem.HTTP.HttpMethod;

namespace SoftUniSystem.MvcFramework;

public static class Host
{
    public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
    {
        List<Route> routeTable = new List<Route>();
        IServiceCollection serviceCollection = new ServiceCollection();

        application.ConfigureServices(serviceCollection);
        application.Configure(routeTable);

        AutoRegisterStaticFile(routeTable);
        AutoRegisterRoutes(routeTable, application, serviceCollection);

        IHttpServer server = new HttpServer(routeTable);

        await server.StartAsync(port);
    }

    private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
    {
        var controllerTypes = application.GetType().Assembly.GetTypes()
             .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));

        foreach (var controllerType in controllerTypes)
        {
            var methods = controllerType
                .GetMethods()
                .Where(x => x.IsPublic && !x.IsStatic && x.DeclaringType == controllerType && !x.IsAbstract && !x.IsConstructor && !x.IsSpecialName);
            foreach (var method in methods)
            {
                var url = '/' + controllerType.Name.Replace("Controller", string.Empty) + "/" + method.Name;
                var attribute = method
                    .GetCustomAttributes(false)
                    .FirstOrDefault(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute))) as BaseHttpAttribute;

                var httpMethod = HttpMethod.Get;

                if (attribute != null)
                {
                    httpMethod = attribute.Method;
                }

                if (!string.IsNullOrEmpty(attribute?.Url))
                {
                    url = attribute.Url;
                }

                routeTable.Add(new Route(url, httpMethod, (request) =>
                {
                    var instance = serviceCollection.CreateInstance(controllerType) as Controller;
                    instance.Request = request;
                    var response = method.Invoke(instance, new object[] {}) as HttpResponse;
                    return response;
                }));
            }
        }
    }

    private static void AutoRegisterStaticFile(List<Route> routeTable)
    {
        var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
        foreach (var staticFile in staticFiles)
        {
            var url = staticFile
                .Replace("wwwroot", string.Empty)
                .Replace("\\", "/");
            routeTable.Add(new Route(url, HttpMethod.Get, (request) =>
            {
                var fileContent = File.ReadAllBytes(staticFile);
                var fileExt = new FileInfo(staticFile).Extension;
                var contentType = fileExt switch
                {
                    ".txt" => "text/plain",
                    ".js" => "text/javascript",
                    ".css" => "text/css",
                    ".jpg" => "image/jpg",
                    ".jpeg" => "image/jpg",
                    ".png" => "image/jpg",
                    ".gif" => "image/gif",
                    ".ico" => "image/vnd.microsoft.icon",
                    ".html" => "text/html",
                    _ => "text/plain"
                };

                return new HttpResponse(contentType, fileContent, HttpStatusCode.Ok);
            }));
        }
    }
}