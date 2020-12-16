using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configs
{
    public class ImportConfig : IEntityTypeConfiguration<Import>
    {
        void IEntityTypeConfiguration<Import>.Configure(EntityTypeBuilder<Import> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.HasOne(m => m.Item)
                .WithMany(o => o.Imports)
                .HasForeignKey(m => m.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}