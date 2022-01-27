using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System.Text;
using System.Web;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
<input type = 'submit' value ='Download Sites Content'/> 
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
  
        public Response Content() => Html(DownloadForm);
        
        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName,
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            if (Request.Cookies.Any(c => c.Name != 
            BasicWebServer.Server.HTTP.Session.SessionCookiesName))
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th</tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");
                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            var currDateKey = "CurrentDate";
            var sessionExists = Request.Session.ContainsKey(currDateKey);

            if (sessionExists)
            {
                var currDate = Request.Session[currDateKey];
                return Text($"Stored date: {currDate}!");
            }

            return Text("Current date stored!");
        }


        private static async Task<string> DownLoadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);
                var html = await response.Content.ReadAsStringAsync();
                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownLoadWebSiteContent(url));
            }

            var response = await Task.WhenAll(downloads);
            var responseString = string.Join(Environment.NewLine + new String('-', 100),
                response);

        }
    }
}
