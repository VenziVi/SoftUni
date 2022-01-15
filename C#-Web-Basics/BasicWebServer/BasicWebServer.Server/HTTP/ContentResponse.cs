using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class ContentResponse : ContentResponse

    {
        public ContentResponse(string _content, string _contentType) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(_content);
            Guard.AgainstNull(_contentType);

            Headers.Add(Header.ContentType, _contentType);

            Body = _content;
        }
    }
}
