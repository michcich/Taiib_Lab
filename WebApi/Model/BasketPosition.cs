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
    public class BasketPosition
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        public int Amount { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BasketPositions)
                .HasForeignKey(bp => bp.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(bp => bp.User)
                .WithMany(u => u.BasketPositions)
                .HasForeignKey(bp => bp.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
