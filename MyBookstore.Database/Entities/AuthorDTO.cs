using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.Entities
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public AuthorDTO()
        {

        }

        public AuthorDTO(string name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }

        public AuthorDTO(int id, string name, DateTime birthDay)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
        }
    }
}
