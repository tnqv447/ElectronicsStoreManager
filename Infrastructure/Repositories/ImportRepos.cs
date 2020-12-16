using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class ImportRepos : Repository<Import>, IImportRepos
    {
        private readonly ElectronicsStoreContext _context;
        public ImportRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}