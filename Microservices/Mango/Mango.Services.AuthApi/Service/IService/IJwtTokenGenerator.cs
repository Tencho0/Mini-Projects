namespace Mango.Services.AuthApi.Service.IService
{
    using Mango.Services.AuthApi.Models;

    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
