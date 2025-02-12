namespace Mango.Web.Models
{
    using static Mango.Web.SD;

    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public string Data { get; set; }

        public string AccessToken { get; set; }

    }
}
