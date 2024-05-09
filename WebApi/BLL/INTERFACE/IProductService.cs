using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDTO> GetAllProducts();
        IEnumerable<ProductResponseDTO> GetProducts(string name);
        IEnumerable<ProductResponseDTO> GetProductsSortedAsc();
        IEnumerable<ProductResponseDTO> GetProductsSortedDesc();
        IEnumerable<ProductResponseDTO> GetActiveProducts();
        bool AddProduct(ProductRequestDTO productRequest);
        bool EditProduct(int productId, ProductRequestDTO productRequest);
        bool DeleteProduct(int productId);
        bool ActivateProduct(int productId);
    }
}
