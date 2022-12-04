using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal class GenreData
    {
        internal static Genre GetGenreInfo()
        {
            return new Genre()
            {
                Id = 1,
                Name = "Action"
            };
        }
        internal static List<Genre> GetGenresInfo()
        {
            return new List<Genre>()
            {
                GetGenreInfo(),
                new Genre()
                {
                    Id = 2,
                    Name = "Fighting"
                }
            };
        }
    }
}
