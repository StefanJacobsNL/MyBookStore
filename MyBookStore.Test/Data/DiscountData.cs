using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal class DiscountData
    {
        internal static Discount GetDiscountInfo()
        {
            return new Discount()
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Amount = 20
            };
        }

        internal static List<Discount> GetDiscountsInfo()
        {
            return new List<Discount>()
            {
                GetDiscountInfo(),
                new Discount()
                {
                    Id = 2,
                    StartDate = DateTime.Now.AddDays(-50),
                    EndDate = DateTime.Now.AddDays(-5),
                    Amount = 30
                },
                new Discount()
                {
                    Id = 3,
                    StartDate = DateTime.Now.AddDays(+50),
                    EndDate = DateTime.Now.AddDays(+55),
                    Amount = 20
                }
            };
        }
    }
}
