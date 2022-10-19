using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.DTO
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public ICollection<BookGenre> BookGenres { get; set; }
        [Required]
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
