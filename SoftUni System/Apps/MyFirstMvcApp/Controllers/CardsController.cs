using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace MyFirstMvcApp.Controllers;

public class CardsController : Controller
{
    public HttpResponse Add()
    {
        return this.View();
    }

    public HttpResponse All()
    {
        return this.View();
    }

    public HttpResponse Collection()
    {
        return this.View();
    }
}