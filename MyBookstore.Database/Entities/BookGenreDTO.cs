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
        public BookDTO Book { get; set; } = new BookDTO();
        public int BookId { get; set; }
        public GenreDTO Genre { get; set; } = new GenreDTO();
        public int GenreId { get; set; }
    }
}
