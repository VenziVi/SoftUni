using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarWithIssuesViewModel
    {
        public string CarId { get; set; }

        public string Year { get; set; }

        public string Model { get; set; }

        public IEnumerable<IssueViewModel> Issues { get; set; }
    }
}
