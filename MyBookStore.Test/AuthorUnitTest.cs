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
    public class AuthorUnitTest
    {
        [Fact]
        public void Get_AllAuthors()
        {
            List<Author> getAuthorData = AuthorData.GetAuthorsInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetAuthors()).Returns(Task.FromResult(getAuthorData));
            BookCatalog bookService = new(bookRepo.Object);

            List<Author> authors = bookService.GetAuthors().Result;

            Assert.NotNull(authors);
            Assert.Equal(getAuthorData.Count(), authors.Count());
        }

        [Fact]
        public void Add_Author()
        {
            Author setupAuthor = AuthorData.GetAuthorInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.AddAuthor(It.IsAny<Author>()));
            BookCatalog bookService = new(bookRepo.Object);

            Result response = bookService.AddAuthor(setupAuthor).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Author()
        {
            Author setupAuthor = AuthorData.GetAuthorInfo();
            Author updateAuthor = setupAuthor;
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetAuthor(It.IsAny<int>())).Returns(Task.FromResult(setupAuthor));
            bookRepo.Setup(x => x.UpdateAuthor(It.IsAny<Author>()));
            var bookService = new BookCatalog(bookRepo.Object);

            updateAuthor.Name = "sdasdasda";
            Result response = bookService.UpdateAuthor(updateAuthor).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
            Assert.Equal(setupAuthor.Name, updateAuthor.Name);
        }

        [Fact]
        public void Delete_Author()
        {
            Author setupAuthor = AuthorData.GetAuthorInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetAuthor(It.IsAny<int>())).Returns(Task.FromResult(setupAuthor));
            bookRepo.Setup(x => x.DeleteAuthor(It.IsAny<int>()));
            BookCatalog bookService = new(bookRepo.Object);

            Result response = bookService.DeleteAuthor(setupAuthor.Id).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

    }
}
