using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Catalog
{
    public interface IBookCatalog
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> AddBook(Book book);
        Task<Result> AddGenre(Genre genre);
        Task<Result> AddWarehouse(Warehouse warehouse);
        Task<Result> DeleteAuthor(int authorId);
        Task<Result> DeleteBook(int bookId);
        Task<Result> DeleteGenre(int genreId);
        Task<Result> DeleteWarehouse(int warehouseId);
        Task<List<Author>> GetAuthors();
        Task<Book> GetBook(int bookId);
        Task<List<Book>> GetBooks(SearchFilter? bookFilter = null);
        Task<List<BookStock>> GetBookStocksBasedOnWarehouses();
        Task<List<Genre>> GetGenres();
        Task<List<Warehouse>> GetWarehouses();
        Task<Result> UpdateAuthor(Author author);
        Task<Result> UpdateBook(Book book);
        Task<Result> UpdateGenre(Genre genre);
        Task<Result> UpdateWarehouse(Warehouse warehouse);
    }
}
