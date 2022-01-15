namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }
        public string Url { get; private set; }
        public HeaderCollection Headers { get; private set; }
        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var startLine = lines.First().Split(" ");
            var method = ParseMethod(startLine[0]);
            var url = startLine[1];
            HeaderCollection headers = ParseHeaders(lines.Skip(1));
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join("\r\n", bodyLines);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var line in headerLines)
            {
                if (line == String.Empty)
                {
                    break;
                }

                var headerParts = line.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException($"Request is not valid");
                }

                var name = headerParts[0];
                var value = headerParts[1].Trim();

                headerCollection.Add(name, value);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not suppoerted");
            }
        }
    }
}
