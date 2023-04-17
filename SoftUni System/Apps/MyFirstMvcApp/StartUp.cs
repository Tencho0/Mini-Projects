using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using BattleCards.Controllers;
using SoftUniSystem.HTTP;
using SoftUniSystem.MvcFramework;
using HttpMethod = SoftUniSystem.HTTP.HttpMethod;

namespace BattleCards;

public class StartUp : IMvcApplication
{
    public void ConfigureServices()
    {
    }

    public void Configure(List<Route> routeTable)
    {
        new ApplicationDbContext().Database.Migrate();
    }
}