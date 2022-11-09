using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Catalog
{
    public interface IBookCatalog
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> AddBook(Book book);
        Task<Result> AddGenre(Genre genre);
        Task<Result> DeleteAuthor(int authorId);
        Task<Result> DeleteBook(int bookId);
        Task<Result> DeleteGenre(int genreId);
        Task<List<Author>> GetAuthors();
        Task<List<Book>> GetBooks();
        Task<List<Genre>> GetGenres();
        Task<Result> UpdateAuthor(Author author);
        Task<Result> UpdateBook(Book book);
        Task<Result> UpdateGenre(Genre genre);
    }
}
