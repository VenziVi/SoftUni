using SMS.Models;
using SMS.Models.HomeModels;
using SMS.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool isCreated, List<ErrorViewModel> Errors) CreateProduct(CreateViewModel model);
        
    }
}
