using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Catalog
{
    public interface IAuthorService
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> DeleteAuthor(int authorId);
        Task<List<Author>> GetAuthors()s;
        Task<Result> UpdateAuthor(Author author);
    }
}
