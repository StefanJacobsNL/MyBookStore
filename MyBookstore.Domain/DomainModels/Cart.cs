using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Cart
    {
        public Dictionary<Book, int> AddedBooks { get; set; } = new();


        public void AddBook(Book book)
        {
            if (!AddedBooks.Any())
            {
                AddedBooks.Add(book, 1);
            }
            else if (AddedBooks.ContainsKey(book))
            {
                AddedBooks[book]++;
            }
            else
            {
                AddedBooks.Add(book, 1);
            }
        }
    }
}
