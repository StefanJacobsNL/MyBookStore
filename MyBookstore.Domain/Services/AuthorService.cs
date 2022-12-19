using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookstore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository AuthorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public async Task<Result> AddAuthor(Author author)
        {
            await AuthorRepository.AddAuthor(author);

            return Result.OK($"The author '{author.Name}' has been added");
        }

        public async Task<Result> DeleteAuthor(int authorId)
        {
            var getAuthor = await AuthorRepository.GetAuthor(authorId);

            if (getAuthor != null && getAuthor.Id > 0)
            {
                await AuthorRepository.DeleteAuthor(getAuthor.Id);

                return Result.OK($"The author '{getAuthor.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await AuthorRepository.GetAuthors();
        }

        public async Task<Result> UpdateAuthor(Author author)
        {
            var getAuthor = await AuthorRepository.GetAuthor(author.Id);

            if (getAuthor != null)
            {
                getAuthor.Name = author.Name;
                getAuthor.BirthDay = author.BirthDay;

                await AuthorRepository.UpdateAuthor(getAuthor);

                return Result.OK($"The author '{getAuthor.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given author doesn't exist");
            }
        }
    }
}
