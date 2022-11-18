using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DiscountDTO()
        {

        }

        public DiscountDTO(decimal discount, DateTime startDate, DateTime endDate)
        {
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
        }

        public DiscountDTO(int id, decimal discount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
