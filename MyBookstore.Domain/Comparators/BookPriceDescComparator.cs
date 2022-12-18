using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Factory;
using MyBookstore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Comparators
{
    public class BookPriceDescComparator : IComparer<Book>
    {
        public int Compare(Book? bookOne, Book? booktwo)
        {
            if (bookOne == null)
            {
                return -1;
            }
            else if (booktwo == null)
            {
                return 1;
            }
            else
            {
                List<Book> books = new()
                {
                    bookOne,
                    booktwo
                };

                books = DiscountService.CalculateBooksDiscountPrice(books, DiscountFactory.GetAllBookDiscountRules());

                return -(books[0].TotalPrice.CompareTo(books[1].TotalPrice));
            }
        }
    }
}
