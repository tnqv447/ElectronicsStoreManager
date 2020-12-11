using System.ComponentModel.DataAnnotations;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs {
    public class CustomerConfig : IEntityTypeConfiguration<Customer> {
        void IEntityTypeConfiguration<Customer>.Configure (EntityTypeBuilder<Customer> builder) {
            builder.HasKey (m => m.Id);
            builder.Property (m => m.Id).ValueGeneratedOnAdd ();

            builder.HasIndex (m => m.Username).IsUnique ();

            builder.Property (m => m.Name)
                .HasMaxLength(40)
                .HasAnnotation("MinLength", 1)
                .IsRequired ();

            builder.Property (m => m.Username)
                .HasMaxLength(30)
                .HasAnnotation("MinLength", 3)
                .IsRequired ();

            builder.Property (m => m.Password)
                .HasMaxLength(30)
                .HasAnnotation("MinLength", 5)
                .IsRequired ();
        }
    }
}