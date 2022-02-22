using Git.Contracts;
using Git.Data.Common;
using Git.Data.ViewModels;
using Git.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IDbRepository repo;

        private readonly IValidationService validationService;

        public RepositoryService(
            IDbRepository _repo,
            IValidationService _validationService
            )
        {
            repo = _repo;
            validationService = _validationService;
        }

        public Repository GetRepo(string id)
        {
            return repo.All<Repository>().FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<AllRepoViewModel> GetRepos()
        {
            return repo.All<Repository>()
                  .Where(r => r.IsPublic == true)
                  .Select(r => new AllRepoViewModel()
                  {
                      Id = r.Id,
                      RepoName = r.Name,
                      Date = r.CreatedOn.ToString("dd.MM.yyyy"),
                      Owner = r.Owner.Username,
                      ComitsCount = r.Commits.Count()
                  }).ToList();
        }

        public bool IsCreated(CreateRepoViewModel model, string id)
        {
            bool isCreated = false;

            bool isValid = validationService.ValidateModel(model);

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                isValid = false;
            }

            if (!isValid)
            {
                return isCreated;
            }

            Repository repository = new Repository()
            {
                Name = model.Name,
                CreatedOn = DateTime.Now,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                OwnerId = id
            };

            try
            {
                repo.Add(repository);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
            }

            return isCreated;
        }
    }
}
