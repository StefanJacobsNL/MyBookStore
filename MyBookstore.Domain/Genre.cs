using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A genre name is required")]
        public string Name { get; set; }

        public Genre()
        {

        }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
