namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;

    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
