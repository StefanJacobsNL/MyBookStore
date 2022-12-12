using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Catalog
{
    public interface IAuthorLogic
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> DeleteAuthor(int authorId);
        Task<List<Author>> GetAuthors();
        Task<Result> UpdateAuthor(Author author);
    }
}
