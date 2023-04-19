using SoftUniSystem.HTTP;

namespace SoftUniSystem.MvcFramework;

public interface IMvcApplication
{
    void ConfigureServices(IServiceCollection serviceCollection);

    void Configure(List<Route> routeTable);
}