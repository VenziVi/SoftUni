using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

public class StartUp
{   
    public static async Task Main()
    {
        await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session())
            .MapGet<UsersController>("/Login", c => c.Login())
            .MapPost<UsersController>("/Login", c => c.LoginUser())
            .MapGet<UsersController>("/Logout", c => c.Logout()))
            //.MapGet<HomeController>("/UserProfile", new HtmlResponse("", StartUp.GetUSerDataAction)))
        .Start();

    }
    //private static void GetUSerDataAction(Request request, Response response)
    //{
    //    if (request.Session.ContainsKey(Session.SessionUserKey))
    //    {
    //        response.Body = String.Empty;
    //        response.Body += $"<h3>Currently logged-in user " + 
    //            $"is with username '{Username}'</h3>";
    //    }
    //    else
    //    {
    //        response.Body = String.Empty;
    //        response.Body += $"<h3>You should first log in " +
    //            $"- <a herf='/Login'>Login</a></h3>";
    //    }
    //}
}
