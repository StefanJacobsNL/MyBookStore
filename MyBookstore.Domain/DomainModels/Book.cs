using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
