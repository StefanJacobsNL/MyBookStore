using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Filters
{
    internal class BookFilterBookGenre : IBookFilter
    {
        public List<Book> Filter(List<Book> books, SearchFilter bookFilter)
        {
            if (books.Any() && bookFilter.Search != null)
            {
                books = books.Where(x => x.Genres.Any(g => g.Name.ToLower().Contains(bookFilter.Search.ToLower()))).ToList();
            }

            return books;
        }
    }
}
