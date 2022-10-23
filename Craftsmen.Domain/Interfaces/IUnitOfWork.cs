namespace Craftsmen.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> Complete();
    }
}
