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
    public class GenreUnitTest
    {
        [Fact]
        public void Get_AllGenres()
        {
            // Get the fake objects
            var getFakeGenresDTO = GetFakeDTOGenres();

            // Converts to fake items to the Genre list
            List<Genre> getFakeGenres = getFakeGenresDTO.Select(x => new Genre(x)).ToList();

            // Mock the Repository
            Mock<IBookRepository> bookRepo = new Mock<IBookRepository>();

            // Setup the return values
            bookRepo.Setup(x => x.GetGenres()).Returns(Task.FromResult(getFakeGenresDTO));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            List<Genre> genres = bookService.GetGenres().Result;

            // Check if object is not null
            Assert.NotNull(genres);

            // Checks if the lists has the same amount of items
            Assert.Equal(getFakeGenres.Count(), genres.Count());
        }

        [Fact]
        public void Add_Genre()
        {
            // Get the fake objects
            var getFakeGenreDTO = GetFakeDTOGenre();

            // Converts to fake item to the Genre object
            Genre setupGenre = new(getFakeGenreDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetGenreByName(It.IsAny<string>())).Returns(Task.FromResult(new GenreDTO()));
            // Setup the add function
            bookRepo.Setup(x => x.AddGenre(It.IsAny<GenreDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.AddGenre(setupGenre).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Genre()
        {
            // Get the fake objects
            var getFakeGenreDTO = GetFakeDTOGenre();

            // Converts to fake item to the Genre object
            Genre setupGenre = new(getFakeGenreDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetGenre(It.IsAny<int>())).Returns(Task.FromResult(getFakeGenreDTO));
            // Setup the add function
            bookRepo.Setup(x => x.UpdateGenre(It.IsAny<GenreDTO>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            setupGenre.Name = "sdasdasda";
            // Get the values of the mock service
            Result response = bookService.UpdateGenre(setupGenre).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
            Assert.Equal(getFakeGenreDTO.Name, setupGenre.Name);
        }

        [Fact]
        public void Delete_Genre()
        {
            // Get the fake objects
            var getFakeGenreDTO = GetFakeDTOGenre();

            // Converts to fake item to the object
            Genre setupGenre = new(getFakeGenreDTO);

            // Mock the Repository
            var bookRepo = new Mock<IBookRepository>();

            // Setup the search function
            bookRepo.Setup(x => x.GetGenre(It.IsAny<int>())).Returns(Task.FromResult(getFakeGenreDTO));
            // Setup the add function
            bookRepo.Setup(x => x.DeleteGenre(It.IsAny<int>()));
            // Create a new service of BookCatalog
            var bookService = new BookCatalog(bookRepo.Object);

            // Get the values of the mock service
            Result response = bookService.DeleteGenre(setupGenre.Id).Result;

            // Check if object is not null
            Assert.NotNull(response);

            // Checks the result
            Assert.True(response.Succes, response.Error);
        }

        internal static List<GenreDTO> GetFakeDTOGenres()
        {
            return new List<GenreDTO>()
            {
                GetFakeDTOGenre(),
                new GenreDTO(2, "Fighting")
            };
        }

        internal static GenreDTO GetFakeDTOGenre()
        {
            return new GenreDTO(1, "Action");
        }
    }
}
