namespace BasicWebServer.Server.HTTP
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';
        public ViewResponse(string _viewName, string _controllerName) 
            : base("", ContentType.Html)
        {
            if (!_viewName.Contains(PathSeparator))
            {
                _viewName = _controllerName + PathSeparator + _viewName;
            }

            var viewPath = Path.GetFullPath($"./Views/" + _viewName.TrimStart(PathSeparator) + ".cshtml");
            var viewContent = File.ReadAllText(viewPath);

            this.Body = viewContent;
        }
    }
}
