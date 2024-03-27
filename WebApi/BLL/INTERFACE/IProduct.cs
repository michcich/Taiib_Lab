using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IProduct
    {
        IEnumerable<ProductDTO> GetProducts(int page, string filterByName, bool? isActive, string sortBy, bool isDescending);
        ProductDTO GetProductById(int productId);
        void AddProduct(ProductDTO product);
        void UpdateProduct(int productId, ProductDTO product);
        void DeleteProduct(int productId);
        void ActivateProduct(int productId);
    }
}
