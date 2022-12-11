using MyBookstore.Domain.DomainModels;
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
                return -(bookOne.CalculateDiscountedPrice().CompareTo(booktwo.CalculateDiscountedPrice()));
            }
        }
    }
}
