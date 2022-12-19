using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddBook(Book book);
        Task DeleteBook(int bookId);
        Task<Book> GetBook(int bookId);
        Task<Book> GetBookByName(string bookName);
        Task<List<Book>> GetBooks();
        Task UpdateBook(Book book);
    }
}
