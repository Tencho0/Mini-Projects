
using HttpMethod = SoftUniSystem.HTTP.HttpMethod;

namespace SoftUniSystem.MvcFramework;

public class HttpGetAttribute : BaseHttpAttribute
{
	public HttpGetAttribute()
	{ }
		
	public HttpGetAttribute(string url)
    {
        this.Url = url;
    }

    public override HttpMethod Method => HttpMethod.Get;
}