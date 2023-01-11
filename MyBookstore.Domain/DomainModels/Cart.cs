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
            else if (AddedBooks.ContainsKey(book) || AddedBooks.Any(x => x.Key.Id == book.Id))
            {
                AddedBooks[AddedBooks.First(x => x.Key.Id == book.Id).Key]++;
            }
            else
            {
                AddedBooks.Add(book, 1);
            }
        }

        public int GetTotalAmountOfBooks()
        {
            return AddedBooks.Sum(x => x.Value);
        }

        public decimal GetTotalPriceBooks()
        {
            decimal totalPrice = 0;

            if (AddedBooks.Any())
            {
                foreach (var addedBook in AddedBooks)
                {
                    totalPrice += addedBook.Key.TotalPrice * addedBook.Value;
                }
            }

            return totalPrice;
        }
    }
}
