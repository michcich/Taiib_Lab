using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IBasketPosition
    {
        void AddProductToBasket(BasketPositionDTO basketPosition);
        void RemoveProductFromBasket(int userId, int productId);
        void ChangeProductAmountInBasket(BasketPositionDTO basketPosition, int amount);
        IEnumerable<BasketPositionDTO> GetBasketContent(int userId);

    }
}
