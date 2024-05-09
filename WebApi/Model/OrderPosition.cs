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
    public class OrderPosition
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
        [Column("ProductID"), Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId)), Required]
        public Product Product { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPositions)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.OrderPositions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
