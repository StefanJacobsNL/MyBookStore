using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Database.Entities
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreDTO()
        {

        }

        public GenreDTO(Genre genre)
        {
            Name = genre.Name;
        }
    }
}
