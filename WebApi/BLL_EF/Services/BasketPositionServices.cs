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
    public class BasketPositionService : IBasketPosition
    {
        private readonly WebshopContext _dbContext;

        public BasketPositionService(WebshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductToBasket(BasketPositionDTO basketPosition)
        {
            if (basketPosition == null)
            {
                throw new ArgumentNullException(nameof(basketPosition));
            }

            var product = _dbContext.Products.FirstOrDefault(p => p.ID == basketPosition.ProductID);
            if (product == null || !product.IsActive)
            {
                throw new Exception("Produkt nie znaleziony");
            }

            if (basketPosition.Amount <= 0)
            {
                throw new Exception("Wartosc ponizej 0");
            }

            var existingBasketPosition = _dbContext.BasketPositions
                .FirstOrDefault(bp => bp.UserID == basketPosition.UserID && bp.ProductID == basketPosition.ProductID);

            if (existingBasketPosition != null)
            {
                existingBasketPosition.Amount += basketPosition.Amount;
            }
            else
            {
                BasketPosition newPosition = new BasketPosition {
                    ProductID = basketPosition.ProductID,
                    Amount = basketPosition.Amount
                };

                _dbContext.BasketPositions.Add(newPosition);
            }

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

        public void ChangeProductAmountInBasket(BasketPositionDTO basketPosition, int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Wartosc ponizej 0");
            }

            BasketPosition? existingBasketPosition = _dbContext.BasketPositions
                .FirstOrDefault(bp => bp.UserID == basketPosition.UserID && bp.ProductID == basketPosition.ProductID);

            if (existingBasketPosition != null)
            {
                existingBasketPosition.Amount = amount;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<BasketPositionDTO> GetBasketContent(int userId)
        {
            List<BasketPosition> basketContent = _dbContext.BasketPositions
                .Where(bp => bp.UserID == userId)
                .ToList();

            List<BasketPositionDTO> returnList = new List<BasketPositionDTO>();
            foreach (BasketPosition item in basketContent)
            {
                var basketPositionDto = new BasketPositionDTO
                {
                    ID = item.ID,
                    ProductID = item.ProductID,
                    UserID = item.UserID,
                    Amount = item.Amount
                };

                returnList.Add(basketPositionDto);
            }

            return returnList;
        }
    }
}
