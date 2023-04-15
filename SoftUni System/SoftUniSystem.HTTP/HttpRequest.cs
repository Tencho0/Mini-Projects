using System.Text;

namespace SoftUniSystem.HTTP;

public class HttpRequest
{
    public HttpRequest(string requestString)
    {
        this.Headers = new List<Header>();
        this.Cookies = new List<Cookie>();

        var lines = requestString.Split(new string[] { HTTPConstants.NewLine }, StringSplitOptions.None);

        var headerLine = lines[0];
        var headerLineParts = headerLine.Split(' ');
        this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);
        this.Path = headerLineParts[1];

        int lineIndex = 1;
        bool isInHeaders = true;
        StringBuilder bodyBuilder = new StringBuilder();
        while (lineIndex < lines.Length)
        {
            var line = lines[lineIndex];
            lineIndex++;

            if (string.IsNullOrWhiteSpace(line))
            {
                isInHeaders = false;
                continue;
            }

            if (isInHeaders)
            {
                this.Headers.Add(new Header(line));
            }
            else
            {
                bodyBuilder.AppendLine(line);
            }
        }

        if (this.Headers.Any(x => x.Name == HTTPConstants.RequestCookieHeader))
        {
            var cookiesAsString = this.Headers.FirstOrDefault(x => x.Name == HTTPConstants.RequestCookieHeader).Value;
            var cookies = cookiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                this.Cookies.Add(new Cookie(cookie));
            }
        }

        this.Body = bodyBuilder.ToString();
    }

    public string Path { get; set; }

    public HttpMethod Method { get; set; }

    public List<Header> Headers { get; set; }

    public List<Cookie> Cookies { get; set; }

    public string Body { get; set; }
}