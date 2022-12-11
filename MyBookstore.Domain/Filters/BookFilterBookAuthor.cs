using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;

namespace MyBookstore.Domain.Filters
{
    internal class BookFilterBookAuthor : IBookFilter
    {
        public List<Book> Filter(List<Book> books, SearchFilter bookFilter)
        {
            if (books.Any() && bookFilter.Search != null)
            {
                books = books.Where(x => x.Authors.Any(g => g.Name.ToLower().Contains(bookFilter.Search.ToLower()))).ToList();
            }

            return books;
        }
    }
}
