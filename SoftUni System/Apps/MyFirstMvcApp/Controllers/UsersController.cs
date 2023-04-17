using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace MyFirstMvcApp.Controllers;

public class UsersController : Controller
{
    public HttpResponse Login()
    {
        return this.View();
    }

    public HttpResponse Register()
    {
        return this.View();
    }

    [HttpPost]
    public HttpResponse DoLogin()
    {
        return this.Redirect("/");
    }
}