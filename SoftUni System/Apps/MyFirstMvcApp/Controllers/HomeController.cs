using MyFirstMvcApp.ViewModels;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace MyFirstMvcApp.Controllers;

public class HomeController : Controller
{
    public HttpResponse Index(HttpRequest request)
    {
        var viewModel = new IndexViewModel();
        viewModel.CurrentYear = DateTime.UtcNow.Year;
        viewModel.Message = "Welcome to Battle Cards";
        return this.View(viewModel);
    }
}