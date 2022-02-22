using Git.Data.Models;
using Git.Data.ViewModels;

namespace Git.Contracts
{
    public interface IRepositoryService
    {
        bool IsCreated(CreateRepoViewModel model, string id);
        IEnumerable<AllRepoViewModel> GetRepos();
        Repository GetRepo(string id);
    }
}
