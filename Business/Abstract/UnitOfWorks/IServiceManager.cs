namespace Business.Abstract.UnitOfWorks
{
    public interface IServiceManager
    {
        public IProductService ProductService {get;}

        public ICategoryService CategoryService {get;}

    }
}