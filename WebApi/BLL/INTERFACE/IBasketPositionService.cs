using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IBasketPositionService
    {
        void AddProductToBasket(BasketPositionRequestDTO basketPosition);
        void RemoveProductFromBasket(int userId, int productId);
        void ChangeProductAmountInBasket(int basketPositionId, int amount);
        IEnumerable<BasketPositionResponseDTO> GetBasketContent(int userId);

    }
}
