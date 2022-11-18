using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public bool SentToCustomer { get; set; }
        public bool Paid { get; set; }

        public OrderDTO()
        {

        }

        public OrderDTO(bool sentToCustomer, bool paid)
        {
            SentToCustomer = sentToCustomer;
            Paid = paid;
        }

        public OrderDTO(int id, bool sentToCustomer, bool paid)
        {
            Id = id;
            SentToCustomer = sentToCustomer;
            Paid = paid;
        }
    }
}
