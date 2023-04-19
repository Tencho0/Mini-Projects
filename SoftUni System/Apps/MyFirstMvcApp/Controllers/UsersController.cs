﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BattleCards.Services;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class UsersController : Controller
{
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    public HttpResponse Login()
    {
        if (this.IsUserSignedIn())
        {
            return this.Redirect("/");
        }

        return this.View();
    }

    [HttpPost("/Users/Login")]
    public HttpResponse DoLogin()
    {
        if (this.IsUserSignedIn())
        {
            return this.Redirect("/");
        }

        var username = this.Request.FormData["username"];
        var password = this.Request.FormData["password"];
        var userId = this.usersService.GetUserId(username, password);

        if (userId == null)
        {
            return this.Error("Invalid username or password!");
        }

        this.SignIn(userId);
        return this.Redirect("/Cards/All");
    }

    public HttpResponse Register()
    {
        if (this.IsUserSignedIn())
        {
            return this.Redirect("/");
        }
        return this.View();
    }

    [HttpPost("/Users/Register")]
    public HttpResponse DoRegister()
    {
        if (this.IsUserSignedIn())
        {
            return this.Redirect("/");
        }

        var username = this.Request.FormData["username"];
        var email = this.Request.FormData["email"];
        var password = this.Request.FormData["password"];
        var confirmPassword = this.Request.FormData["confirmPassword"];

        if (username == null || username.Length < 5 || username.Length > 20)
        {
            return this.Error("Invalid username! The username should be between 5 and 20 characters!");
        }

        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
        {
            return this.Error("Invalid username! Only alphanumeric characters are allowed!");
        }

        if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
        {
            return this.Error("Invalid email!");
        }

        if (password == null || password.Length < 6 || password.Length > 20)
        {
            return this.Error("Invalid username! The username should be between 6 and 20 characters!");
        }

        if (password != confirmPassword)
        {
            return this.Error("Passwords should be the same!");
        }

        if (!this.usersService.IsUsernameAvailable(username))
        {
            return this.Error("Username is already taken!");
        }

        if (!this.usersService.IsEmailAvailable(email))
        {
            return this.Error("Email is already taken!");
        }

        this.usersService.CreateUser(username, email, password);
        return this.Redirect("/Users/Login");
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