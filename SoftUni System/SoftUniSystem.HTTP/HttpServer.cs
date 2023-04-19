using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoftUniSystem.HTTP;

public class HttpServer : IHttpServer
{
    List<Route> routeTable;

    public HttpServer(List<Route> routeTable)
    {
        this.routeTable = routeTable;
    }

    public async Task StartAsync(int port)
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
        tcpListener.Start();

        while (true)
        {
            TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
            ProcessClientAsync(tcpClient);
        }
    }

    private async Task ProcessClientAsync(TcpClient tcpClient)
    {
        try
        {
            using NetworkStream stream = tcpClient.GetStream();
            List<byte> data = new List<byte>();
            int position = 0;
            byte[] buffer = new byte[HTTPConstants.BufferSize];
            while (true)
            {
                int count = await stream.ReadAsync(buffer, position, buffer.Length);
                position += count;

                if (count < buffer.Length)
                {
                    var partialBuffer = new byte[count];
                    Array.Copy(buffer, partialBuffer, count);
                    data.AddRange(partialBuffer);
                    break;
                }
                data.AddRange(buffer);
            }

            var requestAsString = Encoding.UTF8.GetString(data.ToArray());

            var request = new HttpRequest(requestAsString);
            Console.WriteLine($"{request.Method} {request.Path} {request.Headers.Count} headers");

            var route = this.routeTable.FirstOrDefault(x => string.Compare(x.Path, request.Path, StringComparison.OrdinalIgnoreCase) == 0 && x.Method == request.Method);
            var response = route != null
                ? route.Action(request)
                : new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);

            response.Headers.Add(new Header("Server", "SoftUniSystem Server 1.0"));
            var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == HTTPConstants.SessionCookieName);
            if (sessionCookie != null)
            {
                var responseSessionCookie = new ResponseCookie(sessionCookie.Name, sessionCookie.Value);
                responseSessionCookie.Path = "/";
                response.Cookies.Add(responseSessionCookie);
            }

            var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);

            if (response.Body != null)
            {
                await stream.WriteAsync(response.Body, 0, response.Body.Length);
            }

            tcpClient.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}