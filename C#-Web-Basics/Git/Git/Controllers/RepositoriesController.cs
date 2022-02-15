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

            AllRepoViewModel m = new AllRepoViewModel()
            {
                Id = "mmmmmmmm",
                RepoName = "bestRep",
                Date = "12.07.2022",
                Owner = "Venzi",
                ComitsCount = 5
            };

            return View(m);
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
