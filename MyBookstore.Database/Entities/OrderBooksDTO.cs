using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class OrderBooksDTO
    {
        public int Id { get; set; }
        public OrderDTO Order { get; set; }
        public int OrderId { get; set; }
        public BookDTO Book { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }

        public OrderBooksDTO()
        {

        }

        public OrderBooksDTO(int orderId, int bookId, int amount)
        {
            OrderId = orderId;
            BookId = bookId;
            Amount = amount;
        }

        public OrderBooksDTO(int id, int orderId, int bookId, int amount)
        {
            Id = id;
            OrderId = orderId;
            BookId = bookId;
            Amount = amount;
        }
    }
}
