using SoftUniSystem.HTTP;
using SoftUniSystem.MxcFramework;

namespace MyFirstMvcApp.Controllers;

public class HomeController : Controller
{
    public HttpResponse Index(HttpRequest request)
    {
        return this.View();
    }
}