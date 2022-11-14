using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Book : IComparable<Book>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A book name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "A book description is required")]
        public string Description { get; set; } = string.Empty;
        [CustomDate(errorMessage: "A release date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "A price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "A image is required")]
        public string ImagePath { get; set; } = string.Empty;
        public IBrowserFile FileUpload { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        [Required]
        public List<Author> Authors { get; set; } = new List<Author>();


        public Book()
        {

        }

        public Book(BookDTO book)
        {
            Id = book.Id;
            Name = book.Name;
            Description = book.Description;
            ReleaseDate = book.ReleaseDate;
            Price = book.Price;
            ImagePath = book.ImagePath;

            if (book.BookGenres != null)
            {
                foreach (var genre in book.BookGenres)
                {
                    Genres.Add(new Genre(genre.Genre));
                }
            }

            if (book.BookAuthors != null)
            {
                foreach (var author in book.BookAuthors)
                {
                    Authors.Add(new Author(author.Author));
                }
            }
        }

        public bool CheckIfBookHasGenres()
        {
            if (Genres.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfBookHasAuthors()
        {
            if (Genres.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Book? other)
        {
            return this.Name.CompareTo(other?.Name);
        }
    }
}
