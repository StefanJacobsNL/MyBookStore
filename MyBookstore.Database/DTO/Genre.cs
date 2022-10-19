using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.DTO
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
