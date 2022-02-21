using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        bool addIssue(AddIssueViewModel model, string CarId);
        IEnumerable<IssueViewModel> GetIssues(string carId);
        CarWithIssuesViewModel GetCarWithissues(string carId);
        void DeleteIssue(string carId, string issueId);
    }
}
