using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Repository
{
    public interface IGenreRepository
    {
        Task AddGenre(Genre genre);
        Task DeleteGenre(int genreId);
        Task<Genre> GetGenre(int genreId);
        Task<Genre> GetGenreByName(string genreName);
        Task<List<Genre>> GetGenres();
        Task UpdateGenre(Genre genre);
    }
}
