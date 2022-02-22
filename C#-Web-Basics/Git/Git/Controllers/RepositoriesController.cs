using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.Data.ViewModels;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repoServise;
        public RepositoriesController(Request request,
            IRepositoryService _repoServise) 
            : base(request)
        {
            repoServise = _repoServise;
        }

        public Response All()
        {
            IEnumerable<AllRepoViewModel> allRepos = repoServise.GetRepos();

            if (User.IsAuthenticated)
            {
                return View(new
                {
                    IsAuthenticated = true,
                    allRepos
                });
            }

            return View(new 
            {
                IsAuthenticated = false,
                allRepos
            });
        }

        [Authorize]
        public Response Create() => View();

        [HttpPost]
        [Authorize]
        public Response Create(CreateRepoViewModel model)
        {
            bool isCreated = repoServise.IsCreated(model, User.Id);

            if (isCreated)
            {
                return Redirect("/Repositories/All");
            }

            return Redirect("/Repositories/Create");
        }
    }
}
