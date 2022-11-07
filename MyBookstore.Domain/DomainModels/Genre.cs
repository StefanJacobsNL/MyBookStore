using MyBookstore.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Domain.DomainModels
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A genre name is required")]
        public string Name { get; set; }

        public Genre()
        {

        }

        public Genre(GenreDTO genre)
        {
            Id = genre.Id;
            Name = genre.Name;
        }
    }
}
