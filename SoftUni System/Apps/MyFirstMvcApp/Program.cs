using SoftUniSystem.HTTP;
using MyFirstMvcApp.Controllers;
using SoftUniSystem.MxcFramework;
using Route = SoftUniSystem.HTTP.Route;

namespace MyFirstMvcApp;

public class Program
{
    static async Task Main(string[] args)
    {
      

        await Host.CreateHostAsync(routeTable, 80);
    }
}