using Moq;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test
{
    public class AuthorUnitTest
    {
        [Fact]
        public void Get_AllAuthors()
        {
            // Get the fake objects
            var getFakeDTOs = GetFakeDTOAuthors();

            // Converts to fake items to the list
            List<Author> getFakeObjects = getFakeDTOs.Select(x => new Author(x)).ToList();

            // Mock the Repository
            Mock<IBookRepository> bookRepo = new Mock<IBookRepository>();

            // Setup the return values
            bookRepo.Setup(x => x.GetAuthors()).Returns(Task.FromResult(getFakeDTOs));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            List<Author> authors = bookService.GetAuthors().Result;

            // Check if object is not null
            Assert.NotNull(authors);

            // Checks if the lists has the same amount of items
            Assert.Equal(getFakeObjects.Count(), authors.Count());
        }

        [Fact]
        public void Add_Author()
        {
            // Get the fake objects
            var getFakeDTO = GetFakeDTOAuthor();

            // Converts to fake item to the object
            Author setupAuthor = new(getFakeDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the add function
            bookRepo.Setup(x => x.AddAuthor(It.IsAny<AuthorDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.AddAuthor(setupAuthor).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Author()
        {
            // Get the fake objects
            var getFakeDTO = GetFakeDTOAuthor();

            // Converts to fake item to the object
            Author setupAuthor = new(getFakeDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetAuthor(It.IsAny<int>())).Returns(Task.FromResult(getFakeDTO));
            // Setup the add function
            bookRepo.Setup(x => x.UpdateAuthor(It.IsAny<AuthorDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            setupAuthor.Name = "sdasdasda";
            // Get the values of the mock service
            Result response = bookService.UpdateAuthor(setupAuthor).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
            Assert.Equal(getFakeDTO.Name, setupAuthor.Name);
        }

        [Fact]
        public void Delete_Author()
        {
            // Get the fake objects
            var getFakeDTO = GetFakeDTOAuthor();

            // Converts to fake item to the object
            Author setupAuthor = new(getFakeDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetAuthor(It.IsAny<int>())).Returns(Task.FromResult(getFakeDTO));
            // Setup the add function
            bookRepo.Setup(x => x.DeleteAuthor(It.IsAny<int>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.DeleteAuthor(setupAuthor.Id).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }

        internal static List<AuthorDTO> GetFakeDTOAuthors()
        {
            return new List<AuthorDTO>()
            {
                GetFakeDTOAuthor(),
                new AuthorDTO(2, "Astrid C", new DateTime(1970, 7, 14))
            };
        }

        internal static AuthorDTO GetFakeDTOAuthor()
        {
            return new AuthorDTO(1, "Henk B", new DateTime(1960, 12, 30));
        }
    }
}
