using MyBookstore.Database.Entities;

namespace MyBookstore.Database.Repositories
{
    public interface IBookRepository
    {
        Task AddAuthor(AuthorDTO author);
        Task AddBook(BookDTO book);
        Task AddGenre(GenreDTO genre);
        Task DeleteAuthor(int authorId);
        Task DeleteBook(int bookId);
        Task DeleteGenre(int genreId);
        Task<AuthorDTO> GetAuthor(int authorId);
        Task<List<AuthorDTO>> GetAuthors();
        Task<BookDTO> GetBook(int bookId);
        Task<BookDTO> GetBookByName(string bookName);
        Task<List<BookDTO>> GetBooks();
        Task<GenreDTO> GetGenre(int genreId);
        Task<GenreDTO> GetGenreByName(string genreName);
        Task<List<GenreDTO>> GetGenres();
        Task UpdateAuthor(AuthorDTO author);
        Task UpdateBook(BookDTO book);
        Task UpdateGenre(GenreDTO genre);
    }
}
