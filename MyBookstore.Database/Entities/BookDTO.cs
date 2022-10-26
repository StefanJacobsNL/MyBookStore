﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Database.Entities
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public ICollection<BookGenreDTO> BookGenres { get; set; }
        [Required]
        public ICollection<BookAuthorDTO> BookAuthors { get; set; }
    }
}