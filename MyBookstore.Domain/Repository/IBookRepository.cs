using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddAuthor(Author author);
        Task AddBook(Book book);
        Task AddGenre(Genre genre);
        Task AddWarehouse(Warehouse warehouse);
        Task DeleteAuthor(int authorId);
        Task DeleteBook(int bookId);
        Task DeleteGenre(int genreId);
        Task DeleteWarehouse(int warehouseId);
        Task<Author> GetAuthor(int authorId);
        Task<List<Author>> GetAuthors();
        Task<Book> GetBook(int bookId);
        Task<Book> GetBookByName(string bookName);
        Task<List<Book>> GetBooks();
        Task<Genre> GetGenre(int genreId);
        Task<Genre> GetGenreByName(string genreName);
        Task<List<Genre>> GetGenres();
        Task<Warehouse> GetWarehouse(int warehouseId);
        Task<List<Warehouse>> GetWarehouses();
        Task UpdateAuthor(Author author);
        Task UpdateBook(Book book);
        Task UpdateGenre(Genre genre);
        Task UpdateWarehouse(Warehouse warehouse);
    }
}
