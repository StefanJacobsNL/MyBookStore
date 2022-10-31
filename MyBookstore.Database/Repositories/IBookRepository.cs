using MyBookstore.Database.Model;
using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Repositories
{
    public interface IBookRepository
    {
        Task<Result> AddAuthor(Author author);
        Task<Result> AddGenre(Genre genre);
        Task<Result> DeleteAuthor(int authorId);
        Task<Result> DeleteGenre(int genreId);
        Task<List<Author>> GetAuthors();
        Task<List<Genre>> GetGenres();
        Task<Result> UpdateAuthor(Author author);
        Task<Result> UpdateGenre(Genre genre);
    }
}
