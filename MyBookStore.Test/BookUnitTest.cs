using AutoMapper;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using MyBookstore.Domain.Services;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookStore.Test.Data;

namespace MyBookStore.Test
{
    public class BookUnitTest
    {
        [Fact]
        public void Get_AllBooks()
        {
            List<Book> getBookData = BookData.GetBooksInfo();
            Mock<IBookRepository> bookRepo = new();
            bookRepo.Setup(x => x.GetBooks()).Returns(Task.FromResult(getBookData));
            var bookService = new BookService(bookRepo.Object);

            List<Book> books = bookService.GetBooks().Result;

            Assert.NotNull(books);
            Assert.Equal(getBookData.Count(), books.Count());
        }

        [Fact]
        public void Get_Book()
        {
            Book getBookData = BookData.GetBookInfo();
            var bookRepo = new Mock<IBookRepository>();
            bookRepo.Setup(x => x.GetBook(getBookData.Id)).Returns(Task.FromResult(getBookData));
            var bookService = new BookService(bookRepo.Object);

            Book book = bookService.GetBook(getBookData.Id).Result;

            Assert.NotNull(book);
            Assert.Equal(getBookData.Id, book.Id);
            Assert.Equal(getBookData.Name, book.Name);
        }

        [Fact]
        public void Add_Book()
        {
            Book setupBook = BookData.GetBookInfo();
            var bookRepo = new Mock<IBookRepository>();
            bookRepo.Setup(x => x.GetBookByName(It.IsAny<string>())).Returns(Task.FromResult(new Book()));
            bookRepo.Setup(x => x.AddBook(It.IsAny<Book>()));
            var bookService = new BookService(bookRepo.Object);

            Result response = bookService.AddBook(setupBook).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Add_Book_WithExistingName()
        {
            Book setupBook = BookData.GetBookInfo();
            var bookRepo = new Mock<IBookRepository>();
            bookRepo.Setup(x => x.GetBookByName(It.IsAny<string>())).Returns(Task.FromResult(setupBook));
            bookRepo.Setup(x => x.AddBook(It.IsAny<Book>()));
            var bookService = new BookService(bookRepo.Object);

            Result response = bookService.AddBook(setupBook).Result;

            Assert.NotNull(response);
            Assert.False(response.Succes, response.Error);
        }

        [Fact]
        public void Update_Book()
        {
            Book getBookData = BookData.GetBookInfo();
            Book editBook = getBookData;
            var bookRepo = new Mock<IBookRepository>();
            bookRepo.Setup(x => x.GetBook(It.IsAny<int>())).Returns(Task.FromResult(getBookData));
            bookRepo.Setup(x => x.UpdateBook(It.IsAny<Book>()));
            var bookService = new BookService(bookRepo.Object);

            editBook.Name = "sdasdasda";
            Result response = bookService.UpdateBook(editBook).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
            Assert.Equal(getBookData.Name, editBook.Name);
        }

        [Fact]
        public void Delete_Book()
        {
            Book getBookData = BookData.GetBookInfo();
            var bookRepo = new Mock<IBookRepository>();
            bookRepo.Setup(x => x.GetBook(It.IsAny<int>())).Returns(Task.FromResult(getBookData));
            bookRepo.Setup(x => x.DeleteBook(It.IsAny<int>()));
            var bookService = new BookService(bookRepo.Object);

            Result response = bookService.DeleteBook(getBookData.Id).Result;

            Assert.NotNull(response);
            Assert.True(response.Succes, response.Error);
        }

        [Fact]
        public void Get_TotalAmountWarehouseBooks()
        {
            Book book = BookData.GetBookInfo();
            int expectedAmount = 14;

            int amountOfBook = book.GetTotalAmountBooks();

            Assert.Equal(amountOfBook, expectedAmount);
        }

        [Fact]
        public void Calculate_Discount()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = book.CalculateDiscount();

            Assert.Equal(getDiscount, (decimal)2);
        }

        [Fact]
        public void Calculate_DiscountedPrice()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = book.CalculateDiscountedPrice();

            Assert.Equal(getDiscount, (decimal)8);
        }
    }
}
