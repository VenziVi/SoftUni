using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.Data.Models;
using Git.Data.ViewModels;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;
        public CommitsController(Request request,
            ICommitService _commitService,
            IRepositoryService _repositoryService) 
            : base(request)
        {
            commitService = _commitService;
            repositoryService = _repositoryService;
        }

        [Authorize]
        public Response Create(string Id)
        {
            Repository repo = repositoryService.GetRepo(Id);

            return View(repo);
        }

        [HttpPost]
        [Authorize]
        public Response Create(CommitViewmodel model, string Id)
        {
            bool isCreated = commitService.CreateCommit(model, Id, User.Id);

            if (!isCreated)
            {
                return Redirect("/Commits/Create");
            }

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public Response All() => View();
    }
}
