using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Model;
using MyBookstore.Domain;
using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new();

            var test = dbContext.Books.Select(book => new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                ImagePath = book.ImagePath
            });

            return books;
        }

        /// <summary>
        /// Adds a new genre to the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Result class with the response</returns>
        public async Task<Result> AddGenre(Genre genre)
        {
            GenreDTO genreDTO = new(genre);

            var checkIfGenreExist = await dbContext.Genres.Where(x => x.Name.ToLower() == genreDTO.Name.ToLower()).ToListAsync();

            if (!checkIfGenreExist.Any())
            {
                dbContext.Genres.Add(genreDTO);
                await dbContext.SaveChangesAsync();

                return Result.OK($"The genre '{genreDTO.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The genre '{genreDTO.Name}' already exists");
            }
        }
    }
}
