namespace Mango.Services.AuthApi.Service.IService
{
    using Mango.Services.AuthApi.Models.Dto;

    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
