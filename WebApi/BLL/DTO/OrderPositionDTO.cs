using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderPositionDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
