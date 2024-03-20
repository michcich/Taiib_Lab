using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderPositionDTO> OrderPositions { get; set; }
    }
}
