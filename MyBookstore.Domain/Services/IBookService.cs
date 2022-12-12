using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Services
{
    public interface IBookService
    {
        Task<Result> AddBook(Book book);
        Task<Result> DeleteBook(int bookId);
        Task<Book> GetBook(int bookId);
        Task<List<Book>> GetBooks(SearchFilter? bookFilter = null);
        Task<Result> UpdateBook(Book book);
    }
}
