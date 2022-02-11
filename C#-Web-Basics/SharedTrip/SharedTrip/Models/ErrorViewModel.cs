using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string _message)
        {
            ErrorMessage = _message;
        }

        public string ErrorMessage { get; init; }
    }
}
