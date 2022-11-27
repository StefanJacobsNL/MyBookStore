using MyBookstore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal static class BookData
    {
        internal static BookDTO GetBookInfo()
        {
            var bookData = new BookDTO(1, "Test", "Long text", new DateTime(2022, 4, 30), (decimal)10.5, "img/test");
            List<WarehouseBookDTO> getWarehouseBooks = WarehouseBookData.GetWarehouseBooksData();

            foreach (var getWarehouseBook in getWarehouseBooks)
            {
                bookData.BookWarehouses.Add(getWarehouseBook);
            }

            return bookData;
        }
        internal static List<BookDTO> GetBooksInfo()
        {
            List<BookDTO> books = new List<BookDTO>()
            {
                GetBookInfo(),
                new BookDTO(2, "Book test", "Long text sdadfsaasfdasdfsadfsadffsda", new DateTime(2019, 4, 30), 60, "img/test")
            };

            return books;
        }
    }
}
