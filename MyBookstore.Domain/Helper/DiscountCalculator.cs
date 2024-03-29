﻿using MyBookstore.Domain.DiscountRules;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Helper
{
    public static class DiscountCalculator
    {
        public static Book CalculateBookDiscountedPrice(Book book, List<IDiscount> discountRules)
        {
            foreach (var rule in discountRules)
            {
                book = rule.CalculateDiscountedPrice(book);
            }

            return book;
        }

        public static List<Book> CalculateBooksDiscountPrice(List<Book> books, List<IDiscount> discountRules)
        {
            List<Book> calculatedBooks = new();

            foreach (var book in books)
            {
                calculatedBooks.Add(CalculateBookDiscountedPrice(book, discountRules));
            }

            return calculatedBooks;
        }

        public static Book CalculateBookDiscount(Book book, List<IDiscount> discountRules)
        {
            foreach (var rule in discountRules)
            {
                book.TotalDiscount += rule.CalculateDiscount(book);
            }

            return book;
        }

        public static List<Book> CalculateBooksDiscounts(List<Book> books, List<IDiscount> discountRules)
        {
            List<Book> calculatedBooks = new();

            foreach (var book in books)
            {
                calculatedBooks.Add(CalculateBookDiscount(book, discountRules));
            }

            return calculatedBooks;
        }
    }
}
