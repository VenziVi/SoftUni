using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;

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

        public void DeleteIssue(string issueId)
        {
            var issue = repo.All<Issue>().FirstOrDefault(i => i.Id == issueId);

            try
            {
                repo.Delete(issue);
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void Fix(string issueId)
        {
            var issue = repo.All<Issue>().FirstOrDefault(i => i.Id == issueId);

            issue.IsFixed = true;

            repo.SaveChanges();
        }

        public CarWithIssuesViewModel? GetCarWithissues(string CarId)
        {
            return repo.All<Car>()
                .Where(c => c.Id == CarId)
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
