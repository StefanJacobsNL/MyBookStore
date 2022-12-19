using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookstore.Domain.Repository;

namespace MyBookstore.Domain.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository GenreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            GenreRepository = genreRepository;
        }

        public async Task<Result> AddGenre(Genre genre)
        {
            var checkIfGenreExist = await GenreRepository.GetGenreByName(genre.Name);

            if (checkIfGenreExist != null && checkIfGenreExist.Id == 0)
            {
                await GenreRepository.AddGenre(genre);

                return Result.OK($"The genre '{genre.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The genre '{genre.Name}' already exists");
            }
        }

        public async Task<Result> DeleteGenre(int genreId)
        {
            var getGenre = await GenreRepository.GetGenre(genreId);

            if (getGenre != null && getGenre.Id > 0)
            {
                await GenreRepository.DeleteGenre(getGenre.Id);

                return Result.OK($"The genre '{getGenre.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await GenreRepository.GetGenres();
        }

        public async Task<Result> UpdateGenre(Genre genre)
        {
            Genre getGenre = await GenreRepository.GetGenre(genre.Id);

            if (getGenre != null && genre.Id > 0)
            {
                await GenreRepository.UpdateGenre(genre);

                return Result.OK($"The genre '{getGenre.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }
    }
}
