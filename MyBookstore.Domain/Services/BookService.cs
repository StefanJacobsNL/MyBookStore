﻿using MyBookstore.Domain.Comparators;
using MyBookstore.Domain.DiscountRules;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Factory;
using MyBookstore.Domain.Filters;
using MyBookstore.Domain.Interfaces;
using MyBookstore.Domain.Repositories;
using MyBookstore.Domain.Helper;

namespace MyBookstore.Domain.Services
{
    public class BookService : IBookService
    {
        private IBookRepository BookRepository;

        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooks(SearchFilter? bookFilter = null)
        {
            List<Book> books = await BookRepository.GetBooks();

            books = FilterBooks(books, bookFilter);

            books.Sort(new BookNameComparator());

            books = DiscountCalculator.CalculateBooksDiscounts(books, DiscountFactory.GetAllBookDiscountRules());
            books = DiscountCalculator.CalculateBooksDiscountPrice(books, DiscountFactory.GetAllBookDiscountRules());

            return books;
        }

        private List<Book> FilterBooks(List<Book> books, SearchFilter? bookFilter = null)
        {
            List<Book> filteredBooks = new();

            if (bookFilter != null)
            {
                List<IBookFilter> bookFilters = BookFilterFactory.GetAllFilters();

                foreach (var filter in bookFilters)
                {
                    var filterBooks = filter.Filter(books, bookFilter);

                    filteredBooks.AddRange(filterBooks.Where(x => !filteredBooks.Contains(x)));
                }
            }
            else
            {
                filteredBooks = books;
            }

            return filteredBooks;
        }

        public async Task<Book> GetBook(int bookId)
        {
            Book getBook = new();

            var resultBook = await BookRepository.GetBook(bookId);

            if (resultBook != null && resultBook.Id > 0)
            {
                getBook = resultBook;

                getBook = DiscountCalculator.CalculateBookDiscount(getBook, DiscountFactory.GetAllBookDiscountRules());
                getBook = DiscountCalculator.CalculateBookDiscountedPrice(getBook, DiscountFactory.GetAllBookDiscountRules());
            }

            return getBook;
        }

        public async Task<Result> AddBook(Book book)
        {
            var checkIfBookExists = await BookRepository.GetBookByName(book.Name);

            if (checkIfBookExists != null && checkIfBookExists.Id == 0)
            {
                await BookRepository.AddBook(book);

                return Result.OK($"The book '{book.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The book '{book.Name}' already exists");
            }
        }

        public async Task<Result> UpdateBook(Book book)
        {
            var checkBook = await BookRepository.GetBook(book.Id);

            if (checkBook != null && book.Id > 0)
            {
                await BookRepository.UpdateBook(book);

                return Result.OK($"The book '{checkBook.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given book doesn't exist");
            }
        }

        public async Task<Result> DeleteBook(int bookId)
        {
            var getBook = await BookRepository.GetBook(bookId);

            if (getBook != null && getBook.Id > 0)
            {
                await BookRepository.DeleteBook(getBook.Id);

                return Result.OK($"The book '{getBook.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given book doesn't exist");
            }
        }
    }
}
