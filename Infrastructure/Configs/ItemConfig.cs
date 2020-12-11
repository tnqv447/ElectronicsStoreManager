using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs {
    public class ItemConfig : IEntityTypeConfiguration<Item> {
        void IEntityTypeConfiguration<Item>.Configure (EntityTypeBuilder<Item> builder) {
            builder.HasKey (m => m.Id);
            builder.Property (m => m.Id).ValueGeneratedOnAdd ();

            builder.HasMany (m => m.ConsistOf)
                .WithOne (o => o.Parent)
                .HasForeignKey (o => o.ParentId)
                .OnDelete (DeleteBehavior.Restrict);
                
            builder.HasMany (m => m.PartOf)
                .WithOne (o => o.Child)
                .HasForeignKey (o => o.ChildId);

            builder.Property (m => m.Name)
                .IsRequired ();

        }
    }
}