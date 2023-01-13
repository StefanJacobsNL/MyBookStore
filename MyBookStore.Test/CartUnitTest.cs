using MyBookstore.Domain.DomainModels;
using MyBookStore.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test
{
    public class CartUnitTest
    {
        [Fact]
        public void Cart_AddBook()
        {
            Cart cart = new();
            Book book = BookData.GetBookInfo();

            cart.AddBook(book);

            Assert.True(cart.AddedBooks.Any());
        }

        [Fact]
        public void Cart_AddMulitpleBooks()
        {
            Cart cart = new();
            List<Book> books = BookData.GetBooksInfo();

            books.ForEach(x => cart.AddBook(x));

            Assert.True(cart.AddedBooks.Count() > 1);
        }

        [Fact]
        public void Cart_GetTotalAmountOfBooks()
        {
            Cart cart = new();
            List<Book> books = BookData.GetBooksInfo();
            books.ForEach(x => cart.AddBook(x));

            int totalAmount = cart.GetTotalAmountOfBooks();

            Assert.Equal(2, totalAmount);
        }

        [Fact]
        public void Cart_GetTotalAmountOfBooks_WithNoBooksAdded()
        {
            Cart cart = new();

            int totalAmount = cart.GetTotalAmountOfBooks();

            Assert.Equal(0, totalAmount);
        }

        [Fact]
        public void Cart_GetTotalPriceBooks()
        {
            Cart cart = new();
            List<Book> books = BookData.GetBooksInfo();
            books.ForEach(x => cart.AddBook(x));

            decimal totalAmount = cart.GetTotalPriceBooks();

            Assert.Equal(70, totalAmount);
        }

        [Fact]
        public void Cart_GetTotalPriceBooks_WithNoBooksAdded()
        {
            Cart cart = new();

            decimal totalAmount = cart.GetTotalPriceBooks();

            Assert.Equal(0, totalAmount);
        }
    }
}
