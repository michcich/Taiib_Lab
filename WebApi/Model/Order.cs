using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(UserID))]
        public int UserID { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }

        public ICollection<OrderPosition>? OrderPositions { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
