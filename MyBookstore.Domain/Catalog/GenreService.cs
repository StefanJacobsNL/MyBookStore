using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;

namespace MyBookstore.Domain.Catalog
{
    public class GenreService : IGenreService
    {
        private IBookRepository BookRepository;

        public GenreService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<Result> AddGenre(Genre genre)
        {
            var checkIfGenreExist = await BookRepository.GetGenreByName(genre.Name);

            if (checkIfGenreExist != null && checkIfGenreExist.Id == 0)
            {
                await BookRepository.AddGenre(genre);

                return Result.OK($"The genre '{genre.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The genre '{genre.Name}' already exists");
            }
        }

        public async Task<Result> DeleteGenre(int genreId)
        {
            var getGenre = await BookRepository.GetGenre(genreId);

            if (getGenre != null && getGenre.Id > 0)
            {
                await BookRepository.DeleteGenre(getGenre.Id);

                return Result.OK($"The genre '{getGenre.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await BookRepository.GetGenres();
        }

        public async Task<Result> UpdateGenre(Genre genre)
        {
            Genre getGenre = await BookRepository.GetGenre(genre.Id);

            if (getGenre != null && genre.Id > 0)
            {
                await BookRepository.UpdateGenre(genre);

                return Result.OK($"The genre '{getGenre.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }
    }
}
