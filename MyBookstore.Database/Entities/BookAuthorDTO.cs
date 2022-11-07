using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class BookAuthorDTO
    {
        public int Id { get; set; }
        public BookDTO Book { get; set; } = new BookDTO();
        public int BookId { get; set; }
        public AuthorDTO Author { get; set; } = new AuthorDTO();
        public int AuthorId { get; set; }
    }
}
