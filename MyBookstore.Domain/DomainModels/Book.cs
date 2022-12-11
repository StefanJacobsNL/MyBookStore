using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Helper;
using MyBookstore.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Domain.DomainModels
{
    public class Book : IComparable<Book>, IDiscount
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
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<BookStock> BookStocks { get; set; } = new();
        public Discount Discount { get; set; }

        public Book()
        {

        }

        public int CompareTo(Book? other)
        {
            return this.Name.CompareTo(other?.Name);
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

        public int GetTotalAmountBooks()
        {
            int amountOfBooks = 0;

            if (BookStocks != null)
            {
                amountOfBooks += BookStocks.Sum(x => x.Amount);
            }

            return amountOfBooks;
        }

        public decimal CalculateDiscount()
        {
            if (Price > 0 && Discount != null && Discount.CheckIfDateIsValid())
            {
                return (Price / 100) * Discount.Amount;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalculateDiscountedPrice()
        {
            decimal getDiscount = CalculateDiscount();

            if (getDiscount > 0)
            {
                return Price - getDiscount;
            }
            else
            {
                return Price;
            }
        }
    }
}
