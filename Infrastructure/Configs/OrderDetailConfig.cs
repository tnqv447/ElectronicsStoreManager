using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs {
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail> {
        void IEntityTypeConfiguration<OrderDetail>.Configure (EntityTypeBuilder<OrderDetail> builder) {
            builder.HasKey (m => m.Id);
            builder.Property (m => m.Id).ValueGeneratedOnAdd ();

            builder.HasOne (m => m.Item)
                .WithMany ()
                .HasForeignKey (m => m.ItemId)
                .OnDelete (DeleteBehavior.Cascade);

            builder.HasMany (m => m.SubOrderDetails)
                .WithOne (o => o.OrderDetail)
                .HasForeignKey (o => o.OrderDetailId)
                .OnDelete (DeleteBehavior.Cascade);
        }
    }
}