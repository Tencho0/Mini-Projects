using SoftUniSystem.HTTP;
using MyFirstMvcApp.Controllers;
using SoftUniSystem.MvcFramework;   
using Route = SoftUniSystem.HTTP.Route;

namespace MyFirstMvcApp;

public class Program
{
    static async Task Main(string[] args)
    {
        await Host.CreateHostAsync(new StartUp());
    }
}