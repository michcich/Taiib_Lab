using BLL.DTO;
using BLL.DTOResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.INTERFACE
{
    public interface IOrderService
    {
        IEnumerable<OrderResponseDTO> GetAllOrders();
        IEnumerable<OrderResponseDTO> GetUserOrders(int userId);
        IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId);
    }
}
