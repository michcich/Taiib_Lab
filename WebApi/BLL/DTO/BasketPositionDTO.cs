﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BasketPositionDTO
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Amount { get; set; }
    }
}
