using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs {
    public class SubOrderDetailConfig : IEntityTypeConfiguration<SubOrderDetail> {
        void IEntityTypeConfiguration<SubOrderDetail>.Configure (EntityTypeBuilder<SubOrderDetail> builder) {
            builder.HasKey (m => m.Id);
            builder.Property (m => m.Id).ValueGeneratedOnAdd ();

            builder.HasOne (m => m.SubItem)
                .WithMany ()
                .HasForeignKey (m => m.SubItemId)
                .OnDelete (DeleteBehavior.Cascade);

        }
    }
}