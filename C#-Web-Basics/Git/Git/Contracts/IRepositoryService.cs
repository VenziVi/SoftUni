using Git.Data.Models;
using Git.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface IRepositoryService
    {
        bool IsCreated(CreateRepoViewModel model, string id);
        IEnumerable<AllRepoViewModel> GetRepos();
        Repository GetRepo(string id);
    }
}
