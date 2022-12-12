using MyBookstore.Domain.Comparators;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Filters;
using MyBookstore.Domain.Interfaces;

namespace MyBookstore.Domain.Factory
{
    public class BookFilterFactory
    {
        internal static List<IBookFilter> GetAllFilters()
        {
            return new List<IBookFilter>()
            {
                new BookFilterBookName(),
                new BookFilterBookGenre(),
                new BookFilterBookAuthor()
            };
        }
    }
}
