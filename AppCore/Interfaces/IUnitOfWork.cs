namespace AppCore.Interfaces
{
    public interface IUnitOfWork
    {
        IItemRepos ItemRepos { get; }
        ICustomerRepos CustomerRepos { get; }
        IOrderRepos OrderRepos { get; }
        int Complete();
    }
}