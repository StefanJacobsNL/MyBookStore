using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal static class BookData
    {
        internal static Book GetBookInfo()
        {
            return new Book()
            {
                Id = 1,
                Name = "BookOne",
                Description = "This is a book",
                ReleaseDate = new DateTime(2022, 4, 30),
                Price = (decimal)10,
                ImagePath = "img/test",
                BookStocks = BookStockData.GetBookStocksInfo(),
                Discount = DiscountData.GetDiscountInfo(),
                Genres = GenreData.GetGenresInfo()
            };
        }
        internal static List<Book> GetBooksInfo()
        {
            List<Book> books = new()
            {
                GetBookInfo(),
                new Book()
                {
                    Id = 2,
                    Name = "BookTwo",
                    Description = "Long text sdadfsaasfdasdfsadfsadffsda",
                    ReleaseDate = new DateTime(2019, 4, 30),
                    Price = (decimal)60,
                    ImagePath = "img/test",
                    BookStocks = BookStockData.GetBookStocksInfo()
                }
            };

            return books;
        }
    }
}
