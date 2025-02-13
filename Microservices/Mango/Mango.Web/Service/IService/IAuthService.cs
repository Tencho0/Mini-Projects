﻿namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;

    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);

        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);

        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
