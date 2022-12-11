using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.Comparators;
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
        private Dictionary<string, IComparer<Book>> SortDict = new()
        {
            { "A => Z", new BookNameComparator() },
            { "Z => A", new BookNameDescComparator() },
            { "Lowest to highest Price", new BookPriceComparator() },
            { "Highest to lowest Price", new BookPriceDescComparator() },
            { "Lowest to highest discount", new BookDiscountComparator() },
            { "Highest to lowest discount", new BookDiscountDescComparator() }
        };

        protected async override Task OnInitializedAsync()
        {
            searchContext = new EditContext(bookFilter);

            books = await BookCatalog.GetBooks();
        }

        private async Task OnFilterBook()
        {
            books = await BookCatalog.GetBooks(bookFilter);

            SortBooks();
        }

        private void SortBooks(ChangeEventArgs? changeEvent = null)
        {
            if (changeEvent != null && changeEvent.Value != null)
            {
                bookFilter.SortBy = (string)changeEvent.Value;
            }

            if (bookFilter.SortBy != null)
            {
                books.Sort(SortDict[bookFilter.SortBy]);
            }
        }
    }
}
