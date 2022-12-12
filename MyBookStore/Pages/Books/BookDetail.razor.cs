using Microsoft.AspNetCore.Components;
using MyBookstore.Domain.Services;
using MyBookstore.Domain.DomainModels;
using MyBookStore.Components;

namespace MyBookStore.Pages.Books
{
    public partial class BookDetail
    {
        [Parameter]
        public int BookId { get; set; }

        [Inject]
        public IBookService BookCatalog { get; set; } = default!;

        [Inject]
        public Cart Cart { get; set; } = default!;

        private Book? book;

        private Alert? MainAlert { get; set; }

        protected async override Task OnInitializedAsync()
        {
            book = await BookCatalog.GetBook(BookId);
        }

        private void AddToBasket()
        {
            if (book != null)
            {
                Cart.AddBook(book);
                MainAlert?.Show();
            }
        }
    }
}
