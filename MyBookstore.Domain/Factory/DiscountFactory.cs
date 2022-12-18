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
        public static List<IDiscountNew> GetAllDiscountRules()
        {
            return new List<IDiscountNew>()
            {
                new DiscountRuleBook(),
                //new DiscountRuleGenre()
            };
        }

        public static List<IDiscountNew> GetAllBookDiscountRules()
        {
            return new List<IDiscountNew>()
            {
                new DiscountRuleBook(),
                //new DiscountRuleGenre()
            };
        }
    }
}
