using MyBookstore.Domain.DiscountRules;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Factory;
using MyBookstore.Domain.Helper;
using MyBookstore.Domain.Interfaces;
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

        [Fact]
        public void Calculate_Discount_WithDiscountRuleBook()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscount(book, new List<IDiscount> { new DiscountRuleBook() });

            Assert.Equal((decimal)2, getDiscount.TotalDiscount);
        }

        [Fact]
        public void Calculate_Discount_WithDiscountRuleGenre()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscount(book, new List<IDiscount> { new DiscountRuleGenre() });

            Assert.Equal((decimal)2, getDiscount.TotalDiscount);
        }

        [Fact]
        public void Calculate_Discount_WithNoRules()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscount(book, new List<IDiscount>());

            Assert.Equal(0, getDiscount.TotalDiscount);
        }

        [Fact]
        public void Calculate_Discount_WithAllRules()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscount(book, DiscountFactory.GetAllBookDiscountRules());

            Assert.Equal(4, getDiscount.TotalDiscount);
        }

        [Fact]
        public void Calculate_Discount_WithNoBooks()
        {
            Book book = new();

            var getDiscount = DiscountCalculator.CalculateBookDiscount(book, DiscountFactory.GetAllBookDiscountRules());

            Assert.Equal(0, getDiscount.TotalDiscount);
        }

        [Fact]
        public void Calculate_DiscountedPrice_WithDiscountRuleBook()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscountedPrice(book, new List<IDiscount> { new DiscountRuleBook() });

            Assert.Equal((decimal)8, getDiscount.TotalPrice);
        }

        [Fact]
        public void Calculate_DiscountedPrice_WithDiscountRuleGenre()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscountedPrice(book, new List<IDiscount> { new DiscountRuleGenre() });

            Assert.Equal((decimal)8, getDiscount.TotalPrice);
        }

        [Fact]
        public void Calculate_DiscountedPrice_WithNoRules()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscountedPrice(book, new List<IDiscount>());

            Assert.Equal(10, getDiscount.TotalPrice);
        }

        [Fact]
        public void Calculate_DiscountedPrice_WithAllRules()
        {
            Book book = BookData.GetBookInfo();

            var getDiscount = DiscountCalculator.CalculateBookDiscountedPrice(book, DiscountFactory.GetAllBookDiscountRules());

            Assert.Equal((decimal)6.40, getDiscount.TotalPrice);
        }

        [Fact]
        public void Calculate_DiscountedPrice_WithNoBooks()
        {
            Book book = new();

            var getDiscount = DiscountCalculator.CalculateBookDiscountedPrice(book, DiscountFactory.GetAllBookDiscountRules());

            Assert.Equal(0, getDiscount.TotalPrice);
        }
    }
}
