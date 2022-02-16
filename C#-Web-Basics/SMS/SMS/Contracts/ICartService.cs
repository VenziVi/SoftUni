using SMS.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        IEnumerable<CartProductViewModel> AddProductToCart(string id, string productId);
        void BuyProducts(string id);
        IEnumerable<CartProductViewModel> GetUserProduct(string id);
    }
}
