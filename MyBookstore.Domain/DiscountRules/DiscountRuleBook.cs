using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DiscountRules
{
    public class DiscountRuleBook : IDiscount
    {
        public decimal CalculateDiscount(Book book)
        {
            decimal calculateDiscount = 0;

            if (book.Discount != null && book.Discount.CheckIfDateIsValid())
            {
                calculateDiscount = Math.Round((book.Price / 100) * book.Discount.Amount, 2);
            }

            return calculateDiscount;
        }

        public Book CalculateDiscountedPrice(Book book)
        {
            decimal getDiscount = CalculateDiscount(book);

            if (getDiscount > 0 && (book.TotalPrice - getDiscount) >= 0 )
            {
                book.TotalPrice -= getDiscount;
            }

            return book;
        }

        
    }
}
