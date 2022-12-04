using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal class BookStockData
    {
        internal static BookStock GetBookStockInfo()
        {
            return new BookStock(1, "Warehouse 1", 10);
        }

        internal static List<BookStock> GetBookStocksInfo()
        {
            return new List<BookStock>()
            {
                new BookStock(1, "Warehouse 1", 10),
                new BookStock(2, "Warehouse 2", 4)
            };
        }
    }
}
