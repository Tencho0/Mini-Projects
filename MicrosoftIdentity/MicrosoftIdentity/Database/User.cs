namespace MicrosoftIdentity.Database
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
