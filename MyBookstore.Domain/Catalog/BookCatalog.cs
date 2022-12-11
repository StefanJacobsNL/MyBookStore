using AutoMapper;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Filters;
using MyBookstore.Domain.Interfaces;
using MyBookstore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Catalog
{
    public class BookCatalog : IBookCatalog
    {
        private IBookRepository BookRepository;

        public BookCatalog(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        #region Book functions

        public async Task<List<Book>> GetBooks(SearchFilter? bookFilter = null)
        {
            List<Book> getbooks = await BookRepository.GetBooks();
            List<Book> filteredBooks = new();

            if (bookFilter != null)
            {
                List<IBookFilter> bookFilters = new()
                {
                    new BookFilterBookName(),
                    new BookFilterBookGenre(),
                    new BookFilterBookAuthor()
                };

                foreach (var filter in bookFilters)
                {
                    var filterBooks = filter.Filter(getbooks, bookFilter);

                    

                    filteredBooks.AddRange(filterBooks.Where(x => !filteredBooks.Contains(x)));
                }
            }
            else
            {
                filteredBooks = getbooks;
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


        #endregion

        #region BookStocks

        public async Task<List<BookStock>> GetBookStocksBasedOnWarehouses()
        {
            List<BookStock> bookStocks = new();
            List<Warehouse> getWarehouses = await GetWarehouses();

            foreach (var warehouse in getWarehouses)
            {
                bookStocks.Add(new BookStock(warehouse.Id, warehouse.Name));
            }

            return bookStocks;
        }

        #endregion

        #region Genre functions

        public async Task<List<Genre>> GetGenres()
        {
            return await BookRepository.GetGenres();
        }

        public async Task<Result> AddGenre(Genre genre)
        {
            var checkIfGenreExist = await BookRepository.GetGenreByName(genre.Name);

            if (checkIfGenreExist != null && checkIfGenreExist.Id == 0)
            {
                await BookRepository.AddGenre(genre);

                return Result.OK($"The genre '{genre.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The genre '{genre.Name}' already exists");
            }
        }

        public async Task<Result> UpdateGenre(Genre genre)
        {
            Genre getGenre = await BookRepository.GetGenre(genre.Id);

            if (getGenre != null && genre.Id > 0)
            {
                await BookRepository.UpdateGenre(genre);

                return Result.OK($"The genre '{getGenre.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        public async Task<Result> DeleteGenre(int genreId)
        {
            var getGenre = await BookRepository.GetGenre(genreId);

            if (getGenre != null && getGenre.Id > 0)
            {
                await BookRepository.DeleteGenre(getGenre.Id);

                return Result.OK($"The genre '{getGenre.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given genre doesn't exist");
            }
        }

        #endregion

        #region Author functions

        public async Task<List<Author>> GetAuthors()
        {
            return await BookRepository.GetAuthors();
        }

        public async Task<Result> AddAuthor(Author author)
        {
            await BookRepository.AddAuthor(author);

            return Result.OK($"The author '{author.Name}' has been added");
        }

        public async Task<Result> UpdateAuthor(Author author)
        {
            var getAuthor = await BookRepository.GetAuthor(author.Id);

            if (getAuthor != null)
            {
                getAuthor.Name = author.Name;
                getAuthor.BirthDay = author.BirthDay;

                await BookRepository.UpdateAuthor(getAuthor);

                return Result.OK($"The author '{getAuthor.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }

        public async Task<Result> DeleteAuthor(int authorId)
        {
            var getAuthor = await BookRepository.GetAuthor(authorId);

            if (getAuthor != null && getAuthor.Id > 0)
            {
                await BookRepository.DeleteAuthor(getAuthor.Id);

                return Result.OK($"The author '{getAuthor.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }

        #endregion

        #region Warehouse Functions

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await BookRepository.GetWarehouses();
        }

        public async Task<Result> AddWarehouse(Warehouse warehouse)
        {
            await BookRepository.AddWarehouse(warehouse);

            return Result.OK($"The warehouse '{warehouse.Name}' has been added");
        }

        public async Task<Result> UpdateWarehouse(Warehouse warehouse)
        {
            var getWarehouse = await BookRepository.GetWarehouse(warehouse.Id);

            if (getWarehouse != null)
            {
                getWarehouse.Name = warehouse.Name;
                getWarehouse.Address = warehouse.Address;
                getWarehouse.City = warehouse.City;

                await BookRepository.UpdateWarehouse(getWarehouse);

                return Result.OK($"The warehouse '{getWarehouse.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given warehouse doesn't exist");
            }
        }

        public async Task<Result> DeleteWarehouse(int warehouseId)
        {
            var getWarehouse = await BookRepository.GetWarehouse(warehouseId);

            if (getWarehouse != null && getWarehouse.Id > 0)
            {
                await BookRepository.DeleteWarehouse(getWarehouse.Id);

                return Result.OK($"The warehouse '{getWarehouse.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given warehouse doesn't exist");
            }
        }

        #endregion
    }
}
