using MyBookstore.Domain.DomainModels;
using MyBookStore.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test
{
    public class DiscountUnitTest
    {
        [Fact]
        public void DiscountDate_IsValid()
        {
            Discount getDiscountData = DiscountData.GetDiscountInfo();

            var checkIfDateIsValid = getDiscountData.CheckIfDateIsValid();

            Assert.True(checkIfDateIsValid);
        }

        [Fact]
        public void Discount_StartDate_IsInValid()
        {
            Discount getDiscountData = DiscountData.GetDiscountInfo();
            getDiscountData.StartDate = getDiscountData.StartDate.AddDays(1);

            var checkIfDateIsValid = getDiscountData.CheckIfDateIsValid();

            Assert.False(checkIfDateIsValid);
        }

        [Fact]
        public void Discount_EndDate_IsInValid()
        {
            Discount getDiscountData = DiscountData.GetDiscountInfo();
            getDiscountData.EndDate = getDiscountData.EndDate.AddDays(-1);

            var checkIfDateIsValid = getDiscountData.CheckIfDateIsValid();

            Assert.False(checkIfDateIsValid);
        }
    }
}
