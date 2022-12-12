using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Services
{
    public interface IGenreService
    {
        Task<Result> AddGenre(Genre genre);
        Task<Result> DeleteGenre(int genreId);
        Task<List<Genre>> GetGenres();
        Task<Result> UpdateGenre(Genre genre);
    }
}
