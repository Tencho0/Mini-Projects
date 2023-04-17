using SoftUniSystem.MvcFramework;   

namespace BattleCards;

public class Program
{
    static async Task Main(string[] args)
    {
        await Host.CreateHostAsync(new StartUp());
    }
}