using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Catalog
{
    public interface IBookCatalog
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> AddGenre(Genre genre);
        Task<Result> DeleteAuthor(int authorId);
        Task<Result> DeleteGenre(int genreId);
        Task<List<Author>> GetAuthors();
        Task<List<Book>> GetBooks();
        Task<List<Genre>> GetGenres();
        Task<Result> UpdateAuthor(Author author);
        Task<Result> UpdateGenre(Genre genre);
    }
}
