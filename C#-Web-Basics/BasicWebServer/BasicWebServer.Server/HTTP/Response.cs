namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode _statusCode)
        {
            StatusCode = _statusCode;

            Header.Add("Server", "My Web Server");
            Header.Add("Date", $"{DateTime.UtcNow:R}");
        }

        public StatusCode StatusCode { get; init; }
        public HeaderCollection Header { get; } = new HeaderCollection();

        public string Body { get; set; }

    }
}
