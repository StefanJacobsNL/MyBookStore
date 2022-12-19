using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DiscountRules
{
    public class DiscountRuleGenre : IDiscount
    {
        public decimal CalculateDiscount(Book book)
        {
            decimal calculateDiscount = 0;

            if (book.Genres.Any())
            {
                foreach (var genre in book.Genres)
                {
                    if (genre.Discount != null && genre.Discount.CheckIfDateIsValid())
                    {
                        calculateDiscount += Math.Round((book.TotalPrice / 100) * genre.Discount.Amount, 2);
                    }
                }
            }

            return calculateDiscount;
        }

        public Book CalculateDiscountedPrice(Book book)
        {
            decimal getDiscount = CalculateDiscount(book);

            if (getDiscount > 0 && (book.TotalPrice - getDiscount) >= 0)
            {
                book.TotalPrice -= getDiscount;
            }

            return book;
        }
    }
}
