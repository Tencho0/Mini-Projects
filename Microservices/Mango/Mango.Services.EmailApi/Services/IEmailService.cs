namespace Mango.Services.EmailApi.Services
{
    using Mango.Services.EmailApi.Models.Dto;

    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);

        Task RegisterUserEmailAndLog(string email);
    }
}
