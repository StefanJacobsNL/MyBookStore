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
        public void Get_AllBooks()
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
            Assert.Equal(getFakeBooks.Count(), books.Count());
        }

        [Fact]
        public void Get_Book()
        {
            // Get the fake objects
            var getFakeBookDTO = GetFakeDTOBook();

            // Converts to fake item to the Book object
            Book getFakeBook = new Book(getFakeBookDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the return values
            bookRepo.Setup(x => x.GetBook(getFakeBook.Id)).Returns(Task.FromResult(getFakeBookDTO));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Book book = bookService.GetBook(getFakeBook.Id).Result;

            // Check if object is not null
            Assert.NotNull(book);

            // Checks if the lists has the same amount of items
            Assert.Equal(getFakeBook.Id, book.Id);
            Assert.Equal(getFakeBook.Name, book.Name);
        }

        [Fact]
        public void Add_Book()
        {
            // Get the fake objects
            var getFakeBookDTO = GetFakeDTOBook();

            // Converts to fake item to the Book object
            Book setupBook = new(getFakeBookDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetBookByName(It.IsAny<string>())).Returns(Task.FromResult(new BookDTO()));
            // Setup the add function
            bookRepo.Setup(x => x.AddBook(It.IsAny<BookDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.AddBook(setupBook).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Add_Book_WithExistingName()
        {
            // Get the fake objects
            var getFakeBookDTO = GetFakeDTOBook();

            // Converts to fake item to the Book object
            Book setupBook = new(getFakeBookDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetBookByName(It.IsAny<string>())).Returns(Task.FromResult(getFakeBookDTO));
            // Setup the add function
            bookRepo.Setup(x => x.AddBook(It.IsAny<BookDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.AddBook(setupBook).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.False(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Book()
        {
            // Get the fake objects
            var getFakeBookDTO = GetFakeDTOBook();

            // Converts to fake item to the Book object
            Book setupBook = new(getFakeBookDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetBook(It.IsAny<int>())).Returns(Task.FromResult(getFakeBookDTO));
            // Setup the add function
            bookRepo.Setup(x => x.UpdateBook(It.IsAny<BookDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            setupBook.Name = "sdasdasda";
            // Get the values of the mock service
            Result response = bookService.UpdateBook(setupBook).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
            Assert.Equal(getFakeBookDTO.Name, setupBook.Name);
        }

        [Fact]
        public void Delete_Book()
        {
            // Get the fake objects
            var getFakeBookDTO = GetFakeDTOBook();

            // Converts to fake item to the Book object
            Book setupBook = new(getFakeBookDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetBook(It.IsAny<int>())).Returns(Task.FromResult(getFakeBookDTO));
            // Setup the add function
            bookRepo.Setup(x => x.DeleteBook(It.IsAny<int>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.DeleteBook(setupBook.Id).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }


        internal static List<BookDTO> GetFakeDTOBooks()
        {
            return new List<BookDTO>()
            {
                GetFakeDTOBook(),
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

        internal static BookDTO GetFakeDTOBook()
        {
            return new BookDTO()
            {
                Id = 1,
                Name = "Test",
                Description = "Long text",
                ReleaseDate = new DateTime(2022, 4, 30),
                Price = (decimal)10.5
            };
        }
    }
}
