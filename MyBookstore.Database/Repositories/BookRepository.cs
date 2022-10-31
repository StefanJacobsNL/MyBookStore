using Microsoft.AspNetCore.Authentication;
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

        #region Genre Functions

        /// <summary>
        /// Gets all the genres that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Genre>> GetGenres()
        {
            List<Genre> getGenres = new();

            getGenres = await dbContext.Genres.Select(x => new Genre(x.Id, x.Name)).ToListAsync();

            return getGenres;
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

        public async Task<Result> UpdateGenre(Genre genre)
        {
            var getGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genre.Id);

            if (getGenre != null)
            {
                getGenre.Name = genre.Name;

                dbContext.Genres.Update(getGenre);
                await dbContext.SaveChangesAsync();

                return Result.OK($"The genre '{getGenre.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        public async Task<Result> DeleteGenre(int genreId)
        {
            var getGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genreId);

            if (getGenre != null)
            {
                dbContext.Genres.Remove(getGenre);
                await dbContext.SaveChangesAsync();

                return Result.OK($"The genre '{getGenre.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        #endregion

        #region Author Functions

        /// <summary>
        /// Gets all the authors that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Author>> GetAuthors()
        {
            List<Author> getAuthors = new();

            getAuthors = await dbContext.Authors.Select(x => new Author(x.Id, x.Name, x.BirthDay)).ToListAsync();

            return getAuthors;
        }

        /// <summary>
        /// Adds a new author to the database
        /// </summary>
        /// <param name="author"></param>
        /// <returns>Result class with the response</returns>
        public async Task<Result> AddAuthor(Author author)
        {
            AuthorDTO authorDTO = new(author);

            dbContext.Authors.Add(authorDTO);
            await dbContext.SaveChangesAsync();

            return Result.OK($"The author '{authorDTO.Name}' has been added");
        }

        public async Task<Result> UpdateAuthor(Author author)
        {
            var getAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);

            if (getAuthor != null)
            {
                getAuthor.Name = author.Name;
                getAuthor.BirthDay = author.BirthDay;

                dbContext.Authors.Update(getAuthor);
                await dbContext.SaveChangesAsync();

                return Result.OK($"The author '{getAuthor.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }

        public async Task<Result> DeleteAuthor(int authorId)
        {
            var getAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

            if (getAuthor != null)
            {
                dbContext.Authors.Remove(getAuthor);
                await dbContext.SaveChangesAsync();

                return Result.OK($"The author '{getAuthor.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }

        #endregion
    }
}
