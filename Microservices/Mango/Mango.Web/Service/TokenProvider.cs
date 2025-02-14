namespace Mango.Web.Service
{
    using Mango.Web.Service.IService;

    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCoockie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool hasToken = _contextAccessor.HttpContext.Request.Cookies.TryGetValue(SD.TokenCoockie, out token);

            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCoockie, token);
        }
    }
}
