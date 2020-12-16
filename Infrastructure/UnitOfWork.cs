using AppCore.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectronicsStoreContext _context;

        public UnitOfWork(ElectronicsStoreContext context)
        {
            _context = context;
            ItemRepos = new ItemRepos(_context);
            CustomerRepos = new CustomerRepos(_context);
            OrderRepos = new OrderRepos(_context);
            ImportRepos = new ImportRepos(_context);

        }
        public IItemRepos ItemRepos { get; private set; }
        public ICustomerRepos CustomerRepos { get; private set;}
        public IOrderRepos OrderRepos { get; private set;}
        public IImportRepos ImportRepos { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}