using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class GenreDiscountDTO
    {
        public int Id { get; set; }
        public GenreDTO Genre { get; set; }
        public int GenreId { get; set; }
        public DiscountDTO Discount { get; set; }
        public int DiscountId { get; set; }
    }
}
