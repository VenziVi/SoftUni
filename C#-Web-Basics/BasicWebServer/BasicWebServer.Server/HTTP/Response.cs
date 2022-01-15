namespace BasicWebServer.Server.HTTP
{
    public class ContentResponse
    {
        public ContentResponse(StatusCode _statusCode)
        {
            StatusCode = _statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }

        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

    }
}
