using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;

using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

public class StartUp
{
    private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

    private const string DownloadForm = @"<form action='/Content' method='POST'>
<input type = 'submit' value ='Download Sites Content'/> 
</form>";

    private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

    private const string Username = "user";

    private const string Password = "user123";

    private const string FileName = "content.txt";

    public static async Task Main()
        => await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session())
            //.MapGet<HomeController>("/Login", new HtmlResponse(StartUp.LoginForm))
            //.MapPost<HomeController>("/Login", new HtmlResponse("", StartUp.LoginAction))
            //.MapGet<HomeController>("/Logout", new HtmlResponse("", StartUp.LogoutAction))
            //.MapGet<HomeController>("/UserProfile", new HtmlResponse("", StartUp.GetUSerDataAction)))
        .Start();
    

    private static void GetUSerDataAction(Request request, Response response)
    {
        if (request.Session.ContainsKey(Session.SessionUserKey))
        {
            response.Body = String.Empty;
            response.Body += $"<h3>Currently logged-in user " + 
                $"is with username '{Username}'</h3>";
        }
        else
        {
            response.Body = String.Empty;
            response.Body += $"<h3>You should first log in " +
                $"- <a herf='/Login'>Login</a></h3>";
        }
    }

    private static void LogoutAction(Request request, Response response)
    {
        request.Session.Clear();

        response.Body = String.Empty;
        response.Body += "<h3>Logged out Successfully!</h3>";
    }

    private static void LoginAction(Request request, Response response)
    {
        request.Session.Clear();

        var bodyText = string.Empty;
        var usernameMatch = request.Form["Username"] == StartUp.Username;
        var passwordMAtch = request.Form["Password"] == StartUp.Password;

        if (usernameMatch && passwordMAtch)
        {
            request.Session[Session.SessionUserKey] = "MyUserId";
            request.Cookies.Add(Session.SessionCookiesName, request.Session.Id);

            bodyText = "<h3>Logged successfully!</h3>";
        }
        else
        {
            bodyText = StartUp.LoginForm;
        }

        response.Body = String.Empty;
        response.Body += bodyText;
    }

    private static void DisplaySessionInfoAction(Request request, Response response)
    {
        var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);
        var bodytext = string.Empty;

        if (sessionExists)
        {
            var currDate = request.Session[Session.SessionCurrentDateKey];
            bodytext = $"Stared date: {currDate}!";
        }
        else
        {
            bodytext = "Current date stored!";
        }

        response.Body = String.Empty;
        response.Body += bodytext;
    }

    private static void AddCookiesAction(Request request, Response response)
    {
        var requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookiesName); ;
        var bodyText = "";

        if (requestHasCookies)
        {
            var cookieText = new StringBuilder();
            cookieText.AppendLine("<h1>Cookies</h1>");

            cookieText
                .Append("<table border='1'><tr><th>Name</th><th>Value</th</tr>");

            foreach (var cookie in request.Cookies)
            {
                cookieText.Append("<tr>");
                cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                cookieText.Append("</tr>");
            }

            cookieText.Append("</table>");
            bodyText = cookieText.ToString();
        }
        else
        {
            bodyText = "<h1>Cookies set!</h1>";
        }

        if (!requestHasCookies)
        {
            response.Cookies.Add("My-Cookie", "My-Value");
            response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
        }

        response.Body = bodyText;
    }

    private static void AddFormDataAction(Request request, Response response)
    {
        response.Body = "";

        foreach (var (key, value) in request.Form)
        {
            response.Body += $"{key} - {value}";
            response.Body += Environment.NewLine;
        }
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

        await File.WriteAllTextAsync(fileName, responseString);
    }
}
