﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.Entities
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        [Required]
        public ICollection<BookGenreDTO> BookGenres { get; set; } = new List<BookGenreDTO>();
        [Required]
        public ICollection<BookAuthorDTO> BookAuthors { get; set; } = new List<BookAuthorDTO>();

        public BookDTO()
        {

        }

        public BookDTO(string name, string description, decimal price, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
