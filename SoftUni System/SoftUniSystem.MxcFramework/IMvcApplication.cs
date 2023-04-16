using SoftUniSystem.HTTP;

namespace SoftUniSystem.MxcFramework;

public interface IMvcApplication
{
    void ConfigureServices();

    void Configure(List<Route> routeTable);
}