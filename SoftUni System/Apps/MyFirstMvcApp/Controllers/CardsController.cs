using BattleCards.Data;
using BattleCards.ViewModels;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class CardsController : Controller
{
    private readonly ApplicationDbContext db;

    public CardsController(ApplicationDbContext db)
    {
        this.db = db;
    }

    public HttpResponse Add()
    {
        if (!this.IsUserSignedIn())
        {
            return this.Redirect("/Users/Login");
        }   

        return this.View();
    }

    [HttpPost("/Cards/Add")]
    public HttpResponse DoAdd()
    {
        if (!this.IsUserSignedIn())
        {
            return this.Redirect("/Users/Login");
        }

        if (this.Request.FormData["name"].Length < 5)
        {
            return this.Error("Name should be at least 5 characters long!");
        }

        db.Cards.Add(new Card
        {
            Attack = int.Parse(this.Request.FormData["attack"]),
            Health = int.Parse(this.Request.FormData["health"]),
            Description = this.Request.FormData["description"],
            Name = this.Request.FormData["name"],
            ImageUrl = this.Request.FormData["image"],
            Keyword = this.Request.FormData["keyword"]
        });

        db.SaveChanges();
        return this.Redirect("/Cards/All");
    }

    public HttpResponse All()
    {
        if (!this.IsUserSignedIn())
        {
            return this.Redirect("/Users/Login");
        }

        var cardViewModel = db.Cards.Select(x => new CardViewModel()
        {
            Name = x.Name,
            Description = x.Description,
            Attack = x.Attack,
            Health = x.Health,
            ImageUrl = x.ImageUrl,
            Type = x.Keyword
        }).ToList();

        return this.View(cardViewModel);
    }

    public HttpResponse Collection()
    {
        if (!this.IsUserSignedIn())
        {
            return this.Redirect("/Users/Login");
        }

        return this.View();
    }
}