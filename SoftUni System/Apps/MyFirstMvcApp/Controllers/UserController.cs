using System.Text;
using SoftUniSystem.HTTP;
using SoftUniSystem.MxcFramework;

namespace MyFirstMvcApp.Controllers;

public class UserController : Controller
{
    public HttpResponse Login(HttpRequest request)
    {
        var responseHtml = $"<h1>Login...!</h1>{request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value}";
        var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
        var response = new HttpResponse("text/html", responseBodyBytes);

        return response;
    }

    public HttpResponse Register(HttpRequest request)
    {
        var responseHtml = $"<h1>Register...!</h1>{request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value}";
        var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
        var response = new HttpResponse("text/html", responseBodyBytes);

        return response;
    }
}