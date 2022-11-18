using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class OrderDiscountDTO
    {
        public int Id { get; set; }
        public OrderDTO Order { get; set; }
        public int OrderId { get; set; }
        public DiscountDTO Discount { get; set; }
        public int DiscountId { get; set; }
    }
}
