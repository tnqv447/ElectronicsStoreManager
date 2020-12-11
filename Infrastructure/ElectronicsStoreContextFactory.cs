using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class ElectronicsStoreContextFactory : IDesignTimeDbContextFactory<ElectronicsStoreContext>
{
    public ElectronicsStoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ElectronicsStoreContext>();
        optionsBuilder.UseLazyLoadingProxies()
            .UseSqlite($"Data Source=electronics.db");

        return new ElectronicsStoreContext(optionsBuilder.Options);
    }
}
}