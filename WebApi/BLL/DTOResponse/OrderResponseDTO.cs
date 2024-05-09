using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOResponse
{
    public class OrderResponseDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public List<OrderPositionResponseDTO> OrderPositions { get; set; }
    }
}