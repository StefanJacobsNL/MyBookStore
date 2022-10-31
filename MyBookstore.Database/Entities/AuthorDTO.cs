using MyBookstore.Domain;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.Entities
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public AuthorDTO()
        {

        }

        public AuthorDTO(Author author)
        {
            Name = author.Name;
            BirthDay = author.BirthDay;
        }
    }
}
