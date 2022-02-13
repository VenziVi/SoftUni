namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SMS.Contracts;
    using SMS.Data;
    using SMS.Services;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<SMSDbContext>()
                .Add<IUserService, UserService>();

            await server.Start();
        }
    }
}