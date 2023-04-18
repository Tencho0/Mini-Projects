﻿using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class UsersController : Controller
{
    public HttpResponse Login()
    {
        return this.View();
    }

    [HttpPost("/Users/Login")]
    public HttpResponse DoLogin()
    {
        return this.Redirect("/");
    }

    public HttpResponse Register()
    {
        return this.View();
    }

    [HttpPost("/Users/Register")]
    public HttpResponse DoRegister()
    {
        return this.Redirect("/");
    }

    public HttpResponse Logout()
    {
        if (!this.IsUserSignedIn())
        {
            return this.Error("Only logged-in users can logout!");
        }

        this.SignOut();
        return this.Redirect("/");
    }
}