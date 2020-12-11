using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs {
    public class OrderConfig : IEntityTypeConfiguration<Order> {
        void IEntityTypeConfiguration<Order>.Configure (EntityTypeBuilder<Order> builder) {
            builder.HasKey (m => m.Id);
            builder.Property (m => m.Id).ValueGeneratedOnAdd ();

            builder.HasOne (m => m.Customer)
                .WithMany (o => o.Orders)
                .HasForeignKey (m => m.CustomerId)
                .OnDelete (DeleteBehavior.Cascade);

            builder.HasMany (m => m.OrderDetails)
                .WithOne (o => o.Order)
                .HasForeignKey (o => o.OrderId)
                .OnDelete (DeleteBehavior.Cascade);
        }
    }
}