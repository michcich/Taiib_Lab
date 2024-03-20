using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDTO>> GetUserOrdersAsync(int userId);
        Task<IEnumerable<OrderPositionDTO>> GetOrderPositionsAsync(int orderId);
    }
}
