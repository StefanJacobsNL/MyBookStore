using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Repository
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);
        Task DeleteAuthor(int authorId);
        Task<Author> GetAuthor(int authorId);
        Task<List<Author>> GetAuthors();
        Task UpdateAuthor(Author author);
    }
}
