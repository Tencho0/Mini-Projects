using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using BattleCards.Services;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;

namespace BattleCards;

public class StartUp : IMvcApplication
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.Add<IUsersService, UsersService>();
        serviceCollection.Add<ICardsService, CardsService>();
    }

    public void Configure(List<Route> routeTable)
    {
        new ApplicationDbContext().Database.Migrate();
    }
}