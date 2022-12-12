using Moq;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookStore.Test.Data;
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
            List<Genre> getGenreData = GenreData.GetGenresInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetGenres()).Returns(Task.FromResult(getGenreData));
            GenreService genreService = new(bookRepo.Object);

            List<Genre> genres = genreService.GetGenres().Result;

            Assert.NotNull(genres);
            Assert.Equal(getGenreData.Count(), genres.Count());
        }

        [Fact]
        public void Add_Genre()
        {
            Genre setupGenre = GenreData.GetGenreInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetGenreByName(It.IsAny<string>())).Returns(Task.FromResult(new Genre()));
            bookRepo.Setup(x => x.AddGenre(It.IsAny<Genre>()));
            GenreService genreService = new(bookRepo.Object);

            Result response = genreService.AddGenre(setupGenre).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Genre()
        {
            Genre setupGenre = GenreData.GetGenreInfo();
            Genre updateGenre = setupGenre;
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetGenre(It.IsAny<int>())).Returns(Task.FromResult(setupGenre));
            bookRepo.Setup(x => x.UpdateGenre(It.IsAny<Genre>()));
            GenreService genreService = new(bookRepo.Object);

            updateGenre.Name = "sdasdasda";
            Result response = genreService.UpdateGenre(updateGenre).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
            Assert.Equal(setupGenre.Name, updateGenre.Name);
        }

        [Fact]
        public void Delete_Genre()
        {
            Genre setupGenre = GenreData.GetGenreInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetGenre(It.IsAny<int>())).Returns(Task.FromResult(setupGenre));
            bookRepo.Setup(x => x.DeleteGenre(It.IsAny<int>()));
            GenreService genreService = new(bookRepo.Object);

            Result response = genreService.DeleteGenre(setupGenre.Id).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

    }
}
