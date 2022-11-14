using Moq;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;

namespace MyBookStore.Test
{
    public class BookUnitTest
    {
        [Fact]
        public void GetAllBooks()
        {
            // Get the fake objects
            var getFakeBooksDTO = GetFakeDTOBooks();

            // Converts to fake items to the Book list
            List<Book> getFakeBooks = getFakeBooksDTO.Select(x => new Book(x)).ToList();

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the return values
            bookRepo.Setup(x => x.GetBooks()).Returns(Task.FromResult(getFakeBooksDTO));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            List<Book> books = bookService.GetBooks().Result;

            // Check if object is not null
            Assert.NotNull(books);

            // Checks if the lists has the same amount of items
            Assert.Equal(books.Count(), getFakeBooks.Count());
        }

        public static List<BookDTO> GetFakeDTOBooks()
        {
            return new List<BookDTO>()
            {
                new BookDTO()
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Long text",
                    ReleaseDate = new DateTime(2022, 4, 30),
                    Price = (decimal)10.5
                },
                new BookDTO()
                {
                    Id = 2,
                    Name = "Book test",
                    Description = "Long text sdadfsaasfdasdfsadfsadffsda",
                    ReleaseDate = new DateTime(2019, 4, 30),
                    Price = 60
                }
            };
        }
    }
}
