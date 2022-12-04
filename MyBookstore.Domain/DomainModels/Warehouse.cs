using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Domain.DomainModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A warehouse name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "A address is required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "A city is required")]
        public string City { get; set; } = string.Empty;

        public Warehouse()
        {

        }
    }
}
