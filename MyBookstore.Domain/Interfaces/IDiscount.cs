using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Interfaces
{
    public interface IDiscount
    {
        public decimal CalculateDiscount(Book book);
        public Book CalculateDiscountedPrice(Book book);
    }
}
