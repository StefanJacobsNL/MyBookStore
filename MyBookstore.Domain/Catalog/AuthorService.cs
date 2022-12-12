using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Catalog
{
    public class AuthorService : IAuthorService
    {
        private IBookRepository BookRepository;

        public AuthorService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<Result> AddAuthor(Author author)
        {
            await BookRepository.AddAuthor(author);

            return Result.OK($"The author '{author.Name}' has been added");
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

        public async Task<List<Author>> GetAuthors()
        {
            return await BookRepository.GetAuthors();
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
    }
}
