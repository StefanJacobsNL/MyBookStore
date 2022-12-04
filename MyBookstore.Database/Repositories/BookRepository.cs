using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyBookstore.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext dbContext;
        private IMapper Mapper;

        public BookRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            Mapper = mapper;
        }

        #region Book Functions

        public async Task<List<Book>> GetBooks()
        {
            List<Book> books = new();

            var getBooks = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre)
                                         .Include(x => x.BookAuthors).ThenInclude(a => a.Author)
                                         .Include(x => x.BookWarehouses).ThenInclude(x => x.Warehouse).ToListAsync();

            books = Mapper.Map<List<Book>>(getBooks);

            return books;
        }

        public async Task<Book> GetBook(int bookId)
        {
            Book book = new Book();

            var getBook = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre)
                                                 .Include(x => x.BookAuthors).ThenInclude(a => a.Author)
                                                 .Include(x => x.BookWarehouses).ThenInclude(x => x.Warehouse).FirstOrDefaultAsync(x => x.Id == bookId);

            if (getBook != null)
            {
                book = Mapper.Map<Book>(getBook);
            }

            return book;
        }

        public async Task<Book> GetBookByName(string bookName)
        {
            Book book = new Book();

            var checkObject = await dbContext.Books.FirstOrDefaultAsync(x => x.Name.ToLower() == bookName.ToLower());

            if (checkObject != null)
            {
                book = Mapper.Map<Book>(checkObject);
            }

            return book;
        }

        public async Task AddBook(Book book)
        {
            BookDTO bookDTO = Mapper.Map<BookDTO>(book);

            dbContext.Books.Add(bookDTO);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            BookDTO bookDTO = Mapper.Map<BookDTO>(book);

            dbContext.Books.Update(bookDTO);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var getBook = await GetBook(bookId);

            if (getBook != null && getBook.Id > 0)
            {
                BookDTO bookDTO = Mapper.Map<BookDTO>(getBook);
                dbContext.Books.Remove(bookDTO);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Genre Functions

        /// <summary>
        /// Gets all the genres that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Genre>> GetGenres()
        {
            var getGenres = await dbContext.Genres.ToListAsync();
            List<Genre> genres = Mapper.Map<List<Genre>>(getGenres);

            return genres;
        }

        public async Task<Genre> GetGenre(int genreId)
        {
            Genre genre = new();

            var getGenre = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genreId);

            if (getGenre != null)
            {
                genre = Mapper.Map<Genre>(getGenre);
            }

            return genre;
        }

        public async Task<Genre> GetGenreByName(string genreName)
        {
            Genre genre = new Genre();

            var checkObject = await dbContext.Genres.FirstOrDefaultAsync(x => x.Name.ToLower() == genreName.ToLower());

            if (checkObject != null)
            {
                genre = Mapper.Map<Genre>(checkObject);
            }

            return genre;
        }

        /// <summary>
        /// Adds a new genre to the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddGenre(Genre genre)
        {
            GenreDTO genreDTO = Mapper.Map<GenreDTO>(genre);

            dbContext.Genres.Add(genreDTO);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenre(Genre genre)
        {
            GenreDTO genreDTO = Mapper.Map<GenreDTO>(genre);

            dbContext.Genres.Update(genreDTO);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenre(int genreId)
        {
            var getGenre = await GetGenre(genreId);

            if (getGenre != null)
            {
                GenreDTO genreDTO = Mapper.Map<GenreDTO>(getGenre);

                dbContext.Genres.Remove(genreDTO);
                await dbContext.SaveChangesAsync();
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
            var getAuthors = await dbContext.Authors.ToListAsync();

            List<Author> authors = Mapper.Map<List<Author>>(getAuthors); ;

            return authors;
        }

        public async Task<Author> GetAuthor(int authorId)
        {
            Author author = new();

            var getAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

            if (getAuthor != null)
            {
                author = Mapper.Map<Author>(getAuthor);
            }

            return author;
        }

        /// <summary>
        /// Adds a new author to the database
        /// </summary>
        /// <param name="author"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddAuthor(Author author)
        {
            AuthorDTO getAuthor = Mapper.Map<AuthorDTO>(author);
            dbContext.Authors.Add(getAuthor);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            AuthorDTO getAuthor = Mapper.Map<AuthorDTO>(author);
            dbContext.Authors.Update(getAuthor);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int authorId)
        {
            var checkAuthor = await GetAuthor(authorId);

            if (checkAuthor.Id > 0)
            {
                AuthorDTO getAuthor = Mapper.Map<AuthorDTO>(checkAuthor);
                dbContext.Authors.Remove(getAuthor);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Warehouse Functions

        /// <summary>
        /// Gets all the warehouses that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Warehouse>> GetWarehouses()
        {
            var getWarehouses = await dbContext.Warehouses.ToListAsync();

            List<Warehouse> warehouses = Mapper.Map<List<Warehouse>>(getWarehouses);

            return warehouses;
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
            Warehouse warehouse = new();

            var getWarehouse = await dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == warehouseId);

            if (getWarehouse != null)
            {
                warehouse = Mapper.Map<Warehouse>(getWarehouse);
            }

            return warehouse;
        }

        public async Task AddWarehouse(Warehouse warehouse)
        {
            WarehouseDTO getWarehouse = Mapper.Map<WarehouseDTO>(warehouse);
            dbContext.Warehouses.Add(getWarehouse);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            WarehouseDTO getWarehouse = Mapper.Map<WarehouseDTO>(warehouse);
            dbContext.Warehouses.Update(getWarehouse);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWarehouse(int warehouseId)
        {
            var checkWarehouse = await GetWarehouse(warehouseId);

            if (checkWarehouse.Id > 0)
            {
                WarehouseDTO getWarehouse = Mapper.Map<WarehouseDTO>(checkWarehouse);
                dbContext.Warehouses.Remove(getWarehouse);
                await dbContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
