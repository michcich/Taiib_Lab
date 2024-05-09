using BLL.INTERFACE;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL.DTO
{
    public class BasketPositionService : IBasketPositionService
    {
        private readonly WebshopContext _dbContext;

        public BasketPositionService(WebshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductToBasket(BasketPositionRequestDTO basketPosition)
        {
            if (basketPosition == null)
            {
                throw new ArgumentNullException(nameof(basketPosition));
            }

            var product = _dbContext.Products.FirstOrDefault(p => p.ID == basketPosition.ProductId);
            if (product == null || !product.IsActive)
            {
                throw new Exception("Produkt nie znaleziony");
            }

            if (basketPosition.Amount <= 0)
            {
                throw new Exception("Wartosc ponizej 0");
            }

            var existingBasketPosition = _dbContext.BasketPositions
                .FirstOrDefault(bp => bp.UserID == basketPosition.UserId && bp.ProductID == basketPosition.ProductId);

            if (existingBasketPosition != null)
            {
                existingBasketPosition.Amount += basketPosition.Amount;
            }
            else
            {
                BasketPosition newPosition = new BasketPosition
                {
                    ProductID = basketPosition.ProductId,
                    Amount = basketPosition.Amount
                };

                _dbContext.BasketPositions.Add(newPosition);
            }

            _dbContext.SaveChanges();
        }

        public void ChangeProductAmountInBasket(int basketPositionId, int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Wartosc ponizej 0");
            }

            var basketPosition = _dbContext.BasketPositions.SingleOrDefault(x => x.ID == basketPositionId);


            basketPosition.Amount = amount;

            _dbContext.SaveChanges();
        }

        public void RemoveProductFromBasket(int userId, int productId)
        {
            BasketPosition? basketPosition = _dbContext.BasketPositions
                .FirstOrDefault(bp => bp.UserID == userId && bp.ProductID == productId);

            if (basketPosition != null)
            {
                _dbContext.BasketPositions.Remove(basketPosition);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<BasketPositionResponseDTO> GetBasketContent(int userId)
        {
            var basketPositions = _dbContext.BasketPositions
                .Where(position => position.UserID == userId)
                .ToList();

            var basketContentDTOs = basketPositions.Select(position => new BasketPositionResponseDTO
            {
                Id = position.ID,
                ProductId = position.ProductID,
                UserId = position.UserID,
                Amount = position.Amount
            }).ToList();

            return basketContentDTOs;
        }
    }
}
