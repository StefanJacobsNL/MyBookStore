using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class BookGenreDTO
    {
        public int Id { get; set; }
        public BookDTO Book { get; set; }
        public int BookId { get; set; }
        public GenreDTO Genre { get; set; }
        public int GenreId { get; set; }
    }
}
