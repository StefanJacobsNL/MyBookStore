using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;

namespace MyBookStore.Pages
{
    public partial class Index
    {
        [Inject]
        public IBookCatalog BookCatalog { get; set; } = default!;

        private List<Book> books;
        private EditContext? searchContext;
        private SearchFilter bookFilter = new();


        protected async override Task OnInitializedAsync()
        {
            
            searchContext = new EditContext(bookFilter);

            books = await BookCatalog.GetBooks();
        }

        private async Task OnFilterBook()
        {
            books = await BookCatalog.GetBooks(bookFilter);
        }
    }
}
