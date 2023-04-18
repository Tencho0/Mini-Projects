using System.ComponentModel.DataAnnotations;
using SoftUniSystem.MvcFramework;

namespace BattleCards.Data;

public class User: UserIdentity
{
	public User()
    {
        this.Cards = new HashSet<UserCard>();
        this.Id = Guid.NewGuid().ToString();
	}

    public virtual ICollection<UserCard> Cards { get; set; }
}