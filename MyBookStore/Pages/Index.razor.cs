using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Services;
using MyBookstore.Domain.Comparators;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Factory;

namespace MyBookStore.Pages
{
    public partial class Index
    {
        [Inject]
        public IBookService BookCatalog { get; set; } = default!;

        private List<Book>? books;
        private EditContext? searchContext;
        private SearchFilter bookFilter = new();
        private Dictionary<string, IComparer<Book>> SortDict = BookComparerFactory.GetAllComparers();

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

            if (bookFilter.SortBy != null && books != null)
            {
                books.Sort(SortDict[bookFilter.SortBy]);
            }
        }
    }
}
