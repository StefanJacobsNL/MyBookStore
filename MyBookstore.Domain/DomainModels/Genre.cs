using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Domain.DomainModels
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A genre name is required")]
        public string Name { get; set; } = "";
        public Discount? Discount { get; set; }

        public Genre()
        {

        }
    }
}
