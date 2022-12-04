using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal class AuthorData
    {
        internal static Author GetAuthorInfo()
        {
            return new Author()
            {
                Id = 1,
                Name = "Henk B",
                BirthDay = new DateTime(1960, 12, 30)
            };
        }
        internal static List<Author> GetAuthorsInfo()
        {
            return new List<Author>()
            {
                GetAuthorInfo(),
                new Author()
                {
                    Id = 2,
                    Name = "Astrid C",
                    BirthDay = new DateTime(1970, 7, 14)
                }
            };
        }
    }
}
