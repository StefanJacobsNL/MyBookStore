using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class SearchFilter
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; }
    }
}
