using BattleCards.ViewModels;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    public HttpResponse Index()
    {
        var viewModel = new IndexViewModel();
        viewModel.CurrentYear = DateTime.UtcNow.Year;
        viewModel.Message = "Welcome to Battle Cards";
        return this.View(viewModel);
    }

    public HttpResponse About()
    {
        return this.View();
    }
}