using MyBookstore.Domain.Comparators;
using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Factory
{
    public class BookComparerFactory
    {
        public static Dictionary<string, IComparer<Book>> GetAllComparers()
        {
            return new Dictionary<string, IComparer<Book>>()
            {
                { "A => Z", new BookNameComparator() },
                { "Z => A", new BookNameDescComparator() },
                { "Lowest to highest Price", new BookPriceComparator() },
                { "Highest to lowest Price", new BookPriceDescComparator() },
                { "Lowest to highest discount", new BookDiscountComparator() },
                { "Highest to lowest discount", new BookDiscountDescComparator() }
            };
        }
    }
}
