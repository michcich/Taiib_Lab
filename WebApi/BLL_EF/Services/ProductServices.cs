using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.INTERFACE;
using DAL;
using Model;

namespace BLL
{
    public class ProductService : IProductService
    {
        private readonly WebshopContext _dbContext;

        public ProductService(WebshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ActivateProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ID == productId);
            if (product == null)
                return false;

            product.IsActive = true;
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddProduct(ProductRequestDTO productRequest)
        {
            if (productRequest == null || productRequest.Price <= 0)
                return false;

            Product newProduct = new()
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Image = productRequest.Image,
                IsActive = productRequest.IsActive
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ID == productId);
            if (product == null)
                return false;

            if (product.BasketPositions.Any() || product.OrderPositions.Any())
                product.IsActive = false;
            else
                _dbContext.Products.Remove(product);

            _dbContext.SaveChanges();
            return true;
        }

        public bool EditProduct(int productId, ProductRequestDTO productRequest)
        {
            if (productRequest == null || productRequest.Price <= 0)
                return false;

            var product = _dbContext.Products.FirstOrDefault(x => x.ID == productId);
            if (product == null)
                return false;

            product.Name = productRequest.Name;
            product.Price = productRequest.Price;
            product.Image = productRequest.Image;
            product.IsActive = productRequest.IsActive;

            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<ProductResponseDTO> GetActiveProducts()
        {
            return _dbContext.Products.Where(x => x.IsActive).Select(x => new ProductResponseDTO
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }

        public IEnumerable<ProductResponseDTO> GetAllProducts()
        {
            return _dbContext.Products.Select(x => new ProductResponseDTO
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }

        public IEnumerable<ProductResponseDTO> GetProducts(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return _dbContext.Products.Where(x => x.Name.Contains(name)).Select(x => new ProductResponseDTO
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }

        public IEnumerable<ProductResponseDTO> GetProductsSortedAsc()
        {
            return _dbContext.Products.OrderBy(x => x.Price).Select(x => new ProductResponseDTO
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }

        public IEnumerable<ProductResponseDTO> GetProductsSortedDesc()
        {
            return _dbContext.Products.OrderByDescending(x => x.Price).Select(x => new ProductResponseDTO
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }
    }
}
