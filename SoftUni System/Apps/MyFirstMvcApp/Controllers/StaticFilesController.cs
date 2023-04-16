using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace MyFirstMvcApp.Controllers;

public class StaticFilesController : Controller
{
    public HttpResponse Favicon(HttpRequest request)
    {
        return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
    }

    public HttpResponse CustomCss(HttpRequest arg)
    {
        return this.File("wwwroot/css/custom.css", "text/css");
    }

    public HttpResponse CustomJs(HttpRequest arg)
    {
        return this.File("wwwroot/js/custom.js", "text/javascript");
    }

    public HttpResponse BootstrapCss(HttpRequest arg)
    {
        return this.File("wwwroot/css/bootstrap.min.css", "text/css");
    }

    public HttpResponse BootstrapJs(HttpRequest arg)
    {
        return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
    }
}