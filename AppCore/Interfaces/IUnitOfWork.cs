namespace AppCore.Interfaces
{
    public interface IUnitOfWork
    {
        IItemRepos ItemRepos { get; }
        ICustomerRepos CustomerRepos { get; }
        IOrderRepos OrderRepos { get; }
        IImportRepos ImportRepos { get; }
        int Complete();
    }
}