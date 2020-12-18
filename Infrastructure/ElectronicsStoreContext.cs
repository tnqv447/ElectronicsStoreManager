using System.IO;
using AppCore.Models;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure {
    public class ElectronicsStoreContext : DbContext {
        public ElectronicsStoreContext (DbContextOptions<ElectronicsStoreContext> options) : base (options) { }
        protected override void OnModelCreating (ModelBuilder builder) {
            builder.ApplyConfiguration (new ItemConfig ());
            builder.ApplyConfiguration (new CustomerConfig ());
            builder.ApplyConfiguration (new ItemRelationConfig ());
            builder.ApplyConfiguration (new OrderDetailConfig ());
            builder.ApplyConfiguration (new OrderConfig ());
            builder.ApplyConfiguration (new SubOrderDetailConfig ());
            builder.ApplyConfiguration(new ImportConfig());

            base.OnModelCreating (builder);
        }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            var db_path = Path.GetDirectoryName (System.IO.Directory.GetCurrentDirectory ()) + "\\electronics.db";
            // var db_path = "D:\\Code\\Visual Studio\\ElectronicsStoreManager\\electronics.db";
            optionsBuilder.UseSqlite ($"Data Source=" + db_path)
                .UseLazyLoadingProxies ();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemRelation> ItemRelations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SubOrderDetail> SubOrderDetails { get; set; }
        public DbSet<Import> Imports { get; set; }
    }
}