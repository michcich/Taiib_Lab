using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public UserType Type { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BasketPosition>? BasketPositions { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
