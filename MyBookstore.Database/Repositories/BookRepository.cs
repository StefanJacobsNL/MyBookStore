using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;

namespace MyBookstore.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Book Functions

        public async Task<List<BookDTO>> GetBooks()
        {
            List<BookDTO> books = new();

            books = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre)
                                         .Include(x => x.BookAuthors).ThenInclude(a => a.Author)
                                         .Include(x => x.BookWarehouses).ThenInclude(x => x.Warehouse).ToListAsync();

            return books;
        }

        public async Task<BookDTO> GetBook(int bookId)
        {
            BookDTO book = new BookDTO();

            var getBook = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre)
                                                 .Include(x => x.BookAuthors).ThenInclude(a => a.Author)
                                                 .Include(x => x.BookWarehouses).ThenInclude(x => x.Warehouse).FirstOrDefaultAsync(x => x.Id == bookId);

            if (getBook != null)
            {
                book = getBook;
            }

            return book;
        }

        public async Task<BookDTO> GetBookByName(string bookName)
        {
            BookDTO book = new BookDTO();

            var checkObject = await dbContext.Books.FirstOrDefaultAsync(x => x.Name.ToLower() == bookName.ToLower());

            if (checkObject != null)
            {
                book = checkObject;
            }

            return book;
        }

        public async Task AddBook(BookDTO book)
        {
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(BookDTO book)
        {
            dbContext.Books.Update(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var getBook = await GetBook(bookId);

            if (getBook != null && getBook.Id > 0)
            {
                dbContext.Books.Remove(getBook);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Genre Functions

        /// <summary>
        /// Gets all the genres that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<GenreDTO>> GetGenres()
        {
            List<GenreDTO> getGenres = new();

            getGenres = await dbContext.Genres.ToListAsync();

            return getGenres;
        }

        public async Task<GenreDTO> GetGenre(int genreId)
        {
            GenreDTO genre = new GenreDTO();

            var getGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genreId);

            if (getGenre != null)
            {
                genre = getGenre;
            }

            return genre;
        }

        public async Task<GenreDTO> GetGenreByName(string genreName)
        {
            GenreDTO genre = new GenreDTO();

            var checkObject = await dbContext.Genres.FirstOrDefaultAsync(x => x.Name.ToLower() == genreName.ToLower());

            if (checkObject != null)
            {
                genre = checkObject;
            }

            return genre;
        }

        /// <summary>
        /// Adds a new genre to the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddGenre(GenreDTO genre)
        {
            dbContext.Genres.Add(genre);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenre(GenreDTO genre)
        {
            dbContext.Genres.Update(genre);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenre(int genreId)
        {
            var getGenre = await GetGenre(genreId);

            if (getGenre != null)
            {
                dbContext.Genres.Remove(getGenre);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Author Functions

        /// <summary>
        /// Gets all the authors that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<AuthorDTO>> GetAuthors()
        {
            List<AuthorDTO> getAuthors = new();

            getAuthors = await dbContext.Authors.ToListAsync();

            return getAuthors;
        }

        public async Task<AuthorDTO> GetAuthor(int authorId)
        {
            AuthorDTO author = new AuthorDTO();

            var getAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

            if (getAuthor != null)
            {
                author = getAuthor;
            }

            return author;
        }

        /// <summary>
        /// Adds a new author to the database
        /// </summary>
        /// <param name="author"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddAuthor(AuthorDTO author)
        {
            dbContext.Authors.Add(author);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAuthor(AuthorDTO author)
        {
            dbContext.Authors.Update(author);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int authorId)
        {
            var getAuthor = await GetAuthor(authorId);

            if (getAuthor.Id > 0)
            {
                dbContext.Authors.Remove(getAuthor);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Author Functions

        /// <summary>
        /// Gets all the warehouses that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<WarehouseDTO>> GetWarehouses()
        {
            List<WarehouseDTO> getWarehouses = new();

            getWarehouses = await dbContext.Warehouses.ToListAsync();

            return getWarehouses;
        }

        public async Task<WarehouseDTO> GetWarehouse(int warehouseId)
        {
            WarehouseDTO warehouse = new WarehouseDTO();

            var getWarehouse = await dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == warehouseId);

            if (getWarehouse != null)
            {
                warehouse = getWarehouse;
            }

            return warehouse;
        }

        public async Task AddWarehouse(WarehouseDTO warehouse)
        {
            dbContext.Warehouses.Add(warehouse);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateWarehouse(WarehouseDTO warehouse)
        {
            dbContext.Warehouses.Update(warehouse);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWarehouse(int warehouseId)
        {
            var getWarehouse = await GetWarehouse(warehouseId);

            if (getWarehouse.Id > 0)
            {
                dbContext.Warehouses.Remove(getWarehouse);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
