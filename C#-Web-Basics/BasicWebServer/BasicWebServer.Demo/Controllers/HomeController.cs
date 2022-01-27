using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => Text("Hello from this server!");
        public Response Redirect() => Redirect("https://softuni.org/");
        public Response Html() => Html(HtmlForm);
        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }
    }
}
