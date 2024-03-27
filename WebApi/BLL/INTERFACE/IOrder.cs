using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IOrder
    {
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetUserOrders(int userId);
        IEnumerable<OrderPositionDTO> GetOrderPositions(int orderId);
    }
}
