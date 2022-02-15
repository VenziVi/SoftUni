using Git.Contracts;
using Git.Data.Common;
using Git.Data.Models;
using Git.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly IDbRepository repo;

        private readonly IValidationService validationService;

        public CommitService(
            IDbRepository _repo,
            IValidationService _validationService
            )
        {
            repo = _repo;
            validationService = _validationService;
        }



        public bool CreateCommit(CommitViewmodel model,string Id, string userId)
        {
            bool isCreated = false;

            if (string.IsNullOrWhiteSpace(model.Description) ||
                model.Description.Length < 5)
            {
                return isCreated;
            }

            Commit commit = new Commit()
            {
                Description = model.Description,
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositryId = Id
            };

            

            return isCreated;
        }
    }
}
