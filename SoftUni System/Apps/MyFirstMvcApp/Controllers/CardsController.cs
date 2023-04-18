using BattleCards.Data;
using BattleCards.ViewModels;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Controllers;

public class CardsController : Controller
{
    public HttpResponse Add()
    {
        return this.View();
    }

    [HttpPost("/Cards/Add")]
    public HttpResponse DoAdd()
    {
        var dbContext = new ApplicationDbContext();

        if (this.Request.FormData["name"].Length < 5)
        {
            return this.Error("Name should be at least 5 characters long!");
        }

        dbContext.Cards.Add(new Card
        {
            Attack = int.Parse(this.Request.FormData["attack"]),
            Health = int.Parse(this.Request.FormData["health"]),
            Description = this.Request.FormData["description"],
            Name = this.Request.FormData["name"],
            ImageUrl = this.Request.FormData["image"],
            Keyword = this.Request.FormData["keyword"]
        });

        dbContext.SaveChanges();
        return this.View();
    }

    public HttpResponse All()
    {
        var db = new ApplicationDbContext();
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
        return this.View();
    }
}