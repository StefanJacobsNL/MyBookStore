using MyBookstore.Domain.DiscountRules;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Factory
{
    public static class DiscountFactory
    {
        public static List<IDiscount> GetAllDiscountRules()
        {
            return new List<IDiscount>()
            {
                new DiscountRuleBook(),
                new DiscountRuleGenre()
            };
        }

        public static List<IDiscount> GetAllBookDiscountRules()
        {
            return new List<IDiscount>()
            {
                new DiscountRuleBook(),
                new DiscountRuleGenre()
            };
        }
    }
}
