using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Services
{
    public interface IBookCatalog
    {
        Task<Result> AddBook(Book book);
        Task<Result> AddWarehouse(Warehouse warehouse);
        Task<Result> DeleteBook(int bookId);
        Task<Result> DeleteWarehouse(int warehouseId);
        Task<Book> GetBook(int bookId);
        Task<List<Book>> GetBooks(SearchFilter? bookFilter = null);
        Task<List<BookStock>> GetBookStocksBasedOnWarehouses();
        Task<List<Warehouse>> GetWarehouses();
        Task<Result> UpdateBook(Book book);
        Task<Result> UpdateWarehouse(Warehouse warehouse);
    }
}
