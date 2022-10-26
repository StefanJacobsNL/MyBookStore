using MyBookstore.Database.Model;
using MyBookstore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Repositories
{
    public interface IBookRepository
    {
        Task<Result> AddGenre(Genre genre);
    }
}
