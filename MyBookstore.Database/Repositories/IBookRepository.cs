using MyBookstore.Database.Entities;

namespace MyBookstore.Database.Repositories
{
    public interface IBookRepository
    {
        Task AddAuthor(AuthorDTO author);
        Task AddGenre(GenreDTO genre);
        Task DeleteAuthor(int authorId);
        Task DeleteGenre(int genreId);
        Task<AuthorDTO> GetAuthor(int authorId);
        Task<List<AuthorDTO>> GetAuthors();
        Task<List<BookDTO>> GetBooks();
        Task<GenreDTO> GetGenre(int genreId);
        Task<GenreDTO> GetGenreByName(string genreName);
        Task<List<GenreDTO>> GetGenres();
        Task UpdateAuthor(AuthorDTO author);
        Task UpdateGenre(GenreDTO genre);
    }
}
