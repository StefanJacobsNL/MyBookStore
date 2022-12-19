using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Factory;
using MyBookstore.Domain.Helper;

namespace MyBookstore.Domain.Comparators
{
    public class BookDiscountComparator : IComparer<Book>
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

                books = DiscountCalculator.CalculateBooksDiscounts(books, DiscountFactory.GetAllBookDiscountRules());

                return books[0].TotalDiscount.CompareTo(books[1].TotalDiscount);
            }
        }
    }
}
