

namespace BasicWebServer.Server.HTTP
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';
        public ViewResponse(string _viewName, string _controllerName, object model = null) 
            : base("", ContentType.Html)
        {
            if (!_viewName.Contains(PathSeparator))
            {
                _viewName = _controllerName + PathSeparator + _viewName;
            }

            var viewPath = Path.GetFullPath($"./Views/" + _viewName.TrimStart(PathSeparator) + ".cshtml");
            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            this.Body = viewContent;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(p => new
                {
                    p.Name,
                    Value = p.GetValue(model)
                });

            foreach (var item in data)
            {
                const string opening = "{{";
                const string closing = "}}";

                viewContent = viewContent.Replace(
                    $"{opening}{item.Name}{closing}",
                    item.Value.ToString());    
            }

            return viewContent;
        }
    }
}
