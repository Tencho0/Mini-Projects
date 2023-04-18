using BattleCards.ViewModels;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    public HttpResponse Index()
    {
        if (this.IsUserSignedIn())
        {
            return this.Redirect("/Cards/All");
        }

        return this.View();
    }

    public HttpResponse About()
    {
        return this.View();
    }
}