using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.DomainModels;
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

        public async Task<List<Book>> GetBooks()
        {
            List<Book> getBooks = new();

            var resultBooks = await BookRepository.GetBooks();

            getBooks = resultBooks.Select(x => new Book(x)).ToList();

            return getBooks;
        }

        public async Task<Book> GetBook(int bookId)
        {
            Book getBook = new();

            var resultBook = await BookRepository.GetBook(bookId);

            if (resultBook != null && resultBook.Id > 0)
            {
                getBook = new Book(resultBook);
            }

            return getBook;
        }

        public async Task<Result> AddBook(Book book)
        {
            var checkIfBookExists = await BookRepository.GetBookByName(book.Name);

            if (checkIfBookExists != null && checkIfBookExists.Id == 0)
            {
                BookDTO bookDTO = new(book.Name, book.Description, book.ReleaseDate, book.Price, book.ImagePath);

                foreach (var genre in book.Genres)
                {
                    bookDTO.BookGenres.Add(new BookGenreDTO(bookDTO.Id, genre.Id));
                }

                foreach (var author in book.Authors)
                {
                    bookDTO.BookAuthors.Add(new BookAuthorDTO(bookDTO.Id, author.Id));
                }

                await BookRepository.AddBook(bookDTO);

                return Result.OK($"The book '{book.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The book '{book.Name}' already exists");
            }
        }

        public async Task<Result> UpdateBook(Book book)
        {
            var getBook = await BookRepository.GetBook(book.Id);

            if (getBook != null && book.Id > 0)
            {
                getBook.Name = book.Name;
                getBook.Description = book.Description;
                getBook.ReleaseDate = book.ReleaseDate;
                getBook.Price = book.Price;
                getBook.BookGenres = book.Genres.Select(x => new BookGenreDTO(book.Id, x.Id)).ToList();
                getBook.BookAuthors = book.Authors.Select(x => new BookAuthorDTO(book.Id, x.Id)).ToList();

                if (!string.IsNullOrWhiteSpace(book.ImagePath))
                {
                    getBook.ImagePath = book.ImagePath;
                }

                await BookRepository.UpdateBook(getBook);

                return Result.OK($"The book '{getBook.Name}' has been updated");
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

        #region Genre functions

        public async Task<List<Genre>> GetGenres()
        {
            List<Genre> getGenres = new();

            var resultGenres = await BookRepository.GetGenres();

            getGenres = resultGenres.Select(x => new Genre(x)).ToList();

            return getGenres;
        }

        public async Task<Result> AddGenre(Genre genre)
        {
            var checkIfGenreExist = await BookRepository.GetGenreByName(genre.Name);

            if (checkIfGenreExist != null && checkIfGenreExist.Id == 0)
            {
                GenreDTO genreDTO = new(genre.Name);

                await BookRepository.AddGenre(genreDTO);

                return Result.OK($"The genre '{genre.Name}' has been added");
            }
            else
            {
                return Result.Fail($"The genre '{genre.Name}' already exists");
            }
        }

        public async Task<Result> UpdateGenre(Genre genre)
        {
            var getGenre = await BookRepository.GetGenre(genre.Id);

            if (getGenre != null && genre.Id > 0)
            {
                getGenre.Name = genre.Name;

                await BookRepository.UpdateGenre(getGenre);

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
            List<Author> getAuthors = new();

            var resultAuthors = await BookRepository.GetAuthors();

            getAuthors = resultAuthors.Select(x => new Author(x)).ToList();

            return getAuthors;
        }

        public async Task<Result> AddAuthor(Author author)
        {
            AuthorDTO authorDTO = new(author.Name, author.BirthDay);

            await BookRepository.AddAuthor(authorDTO);

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
    }
}
