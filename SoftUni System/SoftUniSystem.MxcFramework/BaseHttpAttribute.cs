
using HttpMethod = SoftUniSystem.HTTP.HttpMethod;

namespace SoftUniSystem.MvcFramework;

public abstract class BaseHttpAttribute : Attribute
{
    public string Url { get; set; }

    public abstract HttpMethod Method { get; }
}