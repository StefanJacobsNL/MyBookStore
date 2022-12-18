using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Helper;
using MyBookstore.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Domain.DomainModels
{
    public class Book
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

        private decimal price { get; set; }

        public decimal Price
        {
            get 
            { 
                return price; 
            }
            set 
            {
                price = value;
                TotalPrice = value; 
            }
        }

        public decimal TotalPrice { get; set; }

        public decimal TotalDiscount { get; set; }

        [Required(ErrorMessage = "A image is required")]
        public string ImagePath { get; set; } = string.Empty;
        public IBrowserFile? FileUpload { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<BookStock> BookStocks { get; set; } = new();
        public Discount? Discount { get; set; }

        public Book()
        {

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

        public string GetGenresString()
        {
            if (Genres.Any())
            {
                return string.Join(", ", Genres.Select(x => x.Name));
            }
            else
            {
                return "-";
            }
        }

        public bool CheckIfBookHasAuthors()
        {
            if (Authors.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetAuthorsString()
        {
            if (Authors.Any())
            {
                return string.Join(", ", Authors.Select(x => x.Name));
            }
            else
            {
                return "-";
            }
        }

        public int GetTotalAmountBooks()
        {
            int amountOfBooks = 0;

            if (BookStocks != null)
            {
                amountOfBooks += BookStocks.Sum(x => x.Amount);
            }

            return amountOfBooks;
        }
    }
}
