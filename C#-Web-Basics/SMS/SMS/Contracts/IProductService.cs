using SMS.Models;
using SMS.Models.ProductModels;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool isCreated, List<ErrorViewModel> Errors) CreateProduct(CreateViewModel model);
        
    }
}
