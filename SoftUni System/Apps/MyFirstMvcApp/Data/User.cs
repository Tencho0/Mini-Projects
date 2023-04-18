using System.ComponentModel.DataAnnotations;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Data;

public class User: IdentityUser<string>
{
	public User()
    {
        this.Cards = new HashSet<UserCard>();
        this.Role = IdentityRole.User;
        this.Id = Guid.NewGuid().ToString();
	}

    public virtual ICollection<UserCard> Cards { get; set; }
}