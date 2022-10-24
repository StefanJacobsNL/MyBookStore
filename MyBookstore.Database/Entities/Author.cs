using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
