using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configs
{
    public class ItemRelationConfig : IEntityTypeConfiguration<ItemRelation>
    {
        void IEntityTypeConfiguration<ItemRelation>.Configure(EntityTypeBuilder<ItemRelation> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

        }
    }
}