using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repository;

namespace MyBookstore.Database.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext dbContext;
        private IMapper Mapper;

        public AuthorRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            Mapper = mapper;
        }

        /// <summary>
        /// Gets all the authors that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Author>> GetAuthors()
        {
            var getAuthors = await dbContext.Authors.ToListAsync();

            List<Author> authors = Mapper.Map<List<Author>>(getAuthors); ;

            return authors;
        }

        public async Task<Author> GetAuthor(int authorId)
        {
            Author author = new();

            var getAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

            if (getAuthor != null)
            {
                author = Mapper.Map<Author>(getAuthor);
            }

            return author;
        }

        /// <summary>
        /// Adds a new author to the database
        /// </summary>
        /// <param name="author"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddAuthor(Author author)
        {
            AuthorDTO getAuthor = Mapper.Map<AuthorDTO>(author);
            dbContext.Authors.Add(getAuthor);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            var dbRequest = await dbContext.Authors.FindAsync(author.Id);

            Mapper.Map(author, dbRequest);

            dbContext.Authors.Update(dbRequest);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int authorId)
        {
            var dbRequest = await dbContext.Authors.FindAsync(authorId);

            if (dbRequest.Id > 0)
            {
                dbContext.Authors.Remove(dbRequest);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
