using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Interfaces
{
    internal interface IBookFilter
    {
        List<Book> Filter(List<Book> books, SearchFilter bookFilter);
    }
}
