namespace DataAccess.Abstract.UnitOfWorks
{
    public interface IRepositoryManager:IAsyncDisposable
    {
        public ICategoryRepository Category {get;}

        public IProductRepository Product {get;}

        Task<int> SaveChangesAsync();
    }
}