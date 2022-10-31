using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A book name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A book description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "A image is required")]
        public string ImagePath { get; set; }

        public Book()
        {

        }

        public Book(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
