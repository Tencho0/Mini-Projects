using SoftUniSystem.HTTP;

namespace SoftUniSystem.MvcFramework;

public interface IMvcApplication
{
    void ConfigureServices();

    void Configure(List<Route> routeTable);
}