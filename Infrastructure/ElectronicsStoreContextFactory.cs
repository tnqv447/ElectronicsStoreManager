using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class ElectronicsStoreContextFactory : IDesignTimeDbContextFactory<ElectronicsStoreContext>
{
    public ElectronicsStoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ElectronicsStoreContext>();

        return new ElectronicsStoreContext(optionsBuilder.Options);
    }
}
}