using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DiscountRules
{
    public class DiscountRuleGenre : IDiscountNew
    {
        public decimal CalculateDiscount(Book book)
        {
            throw new NotImplementedException();
        }

        public Book CalculateDiscountedPrice(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
