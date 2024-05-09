using BLL.INTERFACE;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using BLL.DTOResponse;

namespace BLL.DTO
{
    public class OrderService : IOrderService
    {
        private readonly WebshopContext _dbContext;

        public OrderService(WebshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return _dbContext.Orders.Select(x => new OrderResponseDTO
            {
                ID = x.ID,
                UserID = x.UserID,
                Date = x.Date
            });
        }

        public IEnumerable<OrderResponseDTO> GetUserOrders(int userId)
        {
            return _dbContext.Orders.Where(x => x.UserID == userId).Select(x => new OrderResponseDTO
            {
                ID = x.ID,
                UserID = x.UserID,
                Date = x.Date
            });
        }

        public IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
        {
            return _dbContext.OrderPositions.Where(x => x.OrderID == orderId).Select(x => new OrderPositionResponseDTO
            {
                Id = x.ID,
                OrderId = x.OrderID,
                ProductId = x.ProductId,
                Amount = x.Amount
            });
        }
    }
}
}
