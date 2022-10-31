using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
