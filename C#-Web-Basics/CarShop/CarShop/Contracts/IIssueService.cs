using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        bool addIssue(AddIssueViewModel model, string CarId);
        IEnumerable<IssueViewModel> GetIssues(string carId);
        CarWithIssuesViewModel GetCarWithissues(string carId);
        void DeleteIssue(string issueId);
        void Fix(string issueId);
    }
}
