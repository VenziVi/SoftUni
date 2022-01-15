namespace BasicWebServer.Server.HTTP
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string _text) 
            : base(_text, ContentType.PlainText)
        {
        }
    }
}
