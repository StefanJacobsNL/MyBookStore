using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using System.Net;
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

        public async Task<List<Book>> GetBooks()
        {
            List<Book> books = new();

            var getBooks = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre).ThenInclude(x => x.Discount)
                                         .Include(x => x.BookAuthors).ThenInclude(a => a.Author)
                                         .Include(x => x.BookWarehouses).ThenInclude(x => x.Warehouse)
                                         .Include(x => x.Discount).ToListAsync();

            books = Mapper.Map<List<Book>>(getBooks);

            return books;
        }

        public async Task<Book> GetBook(int bookId)
        {
            Book book = new Book();

            var getBook = await dbContext.Books.Include(x => x.BookGenres).ThenInclude(g => g.Genre).ThenInclude(x => x.Discount)
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
            var dbRequest = await dbContext.Books.FindAsync(book.Id);

            Mapper.Map(book, dbRequest);

            dbContext.Books.Update(dbRequest);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var dbRequest = await dbContext.Books.FindAsync(bookId);

            if (dbRequest != null && dbRequest.Id > 0)
            {
                dbContext.Books.Remove(dbRequest);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
