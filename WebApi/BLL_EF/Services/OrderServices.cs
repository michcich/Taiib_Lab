using BLL.INTERFACE;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL.DTO
{
    public class OrderService : IOrder
    {
        private readonly WebshopContext _dbContext;

        public OrderService(WebshopContext dbContext)
        {
            _dbContext = dbContext;
        }


        IEnumerable<OrderDTO> IOrder.GetAllOrders()
        {
            IEnumerable<Order> orders = _dbContext.Orders.ToList();
            IEnumerable<OrderDTO> orderDTOs = orders.Select(o => new OrderDTO
            {
                ID = o.ID,
                UserID = o.UserID,
                Date = o.Date,
                OrderPositions = o.OrderPositions.Select(op => new OrderPositionDTO
                {
                    ID = op.ID,
                    OrderID = op.OrderID,
                    Amount = op.Amount,
                    Price = op.Price
                }).ToList()
            });
            return orderDTOs;
        }

        IEnumerable<OrderDTO> IOrder.GetUserOrders(int userId)
        {
            List<Order> userOrders = _dbContext.Orders
                .Where(o => o.UserID == userId)
                .ToList();

            IEnumerable<OrderDTO> userOrderDTOs = userOrders.Select(o => new OrderDTO
            {
                ID = o.ID,
                UserID = o.UserID,
                Date = o.Date,
                OrderPositions = o.OrderPositions.Select(op => new OrderPositionDTO
                {
                    ID = op.ID,
                    OrderID = op.OrderID,
                    Amount = op.Amount,
                    Price = op.Price
                }).ToList()
            });

            return userOrderDTOs;
        }

        IEnumerable<OrderPositionDTO> IOrder.GetOrderPositions(int orderId)
        {
            Order? order = _dbContext.Orders.FirstOrDefault(o => o.ID == orderId);

            if (order == null)
            {
                throw new Exception("Nie znaleziono zamowiena.");
            }

            List<OrderPositionDTO> orderPositionDTOs = order.OrderPositions.Select(op => new OrderPositionDTO
            {
                ID = op.ID,
                OrderID = op.OrderID,
                Amount = op.Amount,
                Price = op.Price
            }).ToList();

            return orderPositionDTOs;
        }
    }
}
