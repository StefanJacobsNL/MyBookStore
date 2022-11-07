namespace MyBookstore.Database.Entities
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public GenreDTO()
        {

        }

        public GenreDTO(string name)
        {
            Name = name;
        }

        public GenreDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
