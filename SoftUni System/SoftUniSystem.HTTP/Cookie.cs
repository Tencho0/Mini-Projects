﻿namespace SoftUniSystem.HTTP;

public class Cookie
{
    public Cookie(string cookieAsString)
    {
        var cookieParts = cookieAsString.Split(new char[] { '=' }, 2);
        this.Name = cookieParts[0];
        this.Value = cookieParts[1];
    }

    public string Name { get; set; }

    public string Value { get; set; }
}