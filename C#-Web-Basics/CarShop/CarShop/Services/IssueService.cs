using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{


    public class IssueService : IIssueService
    {
        private readonly IRepository repo;

        public IssueService(IRepository _repo)
        {
            repo = _repo;
        }

        public bool addIssue(AddIssueViewModel model, string carId)
        {
            bool isAdded = false;

            Issue issue = new Issue()
            {
                CarId = carId,
                Description = model.Description,
                IsFixed = false
            };

            try
            {
                repo.Add(issue);
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {
            }

            return isAdded;
        }

        public CarWithIssuesViewModel? GetCarWithissues(string carId)
        {
            return repo.All<Car>()
                .Where(c => c.Id == carId)
                .Select(c => new CarWithIssuesViewModel()
                {
                    CarId = c.Id,
                    Model = c.Model,
                    Year = c.Year.ToString(),
                    Issues = c.Issues.Select(i => new IssueViewModel()
                    {
                        IssueId = i.Id,
                        IsFixed = i.IsFixed ? "Yes" : "Not Yet",
                        Description = i.Description
                    }).ToList()
                }).FirstOrDefault();
        }

        public IEnumerable<IssueViewModel> GetIssues(string carId)
        {

            return repo
                .All<Issue>()
                .Where(i => i.CarId == carId)
                .Select(i => new IssueViewModel()
                {
                    IssueId = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed ? "Yes" : "Not Yet"
                }).ToList();

        }
    }
}
