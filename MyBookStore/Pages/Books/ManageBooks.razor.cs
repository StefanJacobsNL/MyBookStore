using Microsoft.AspNetCore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Components;
using MyBookstore.Domain.DomainModels;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;

namespace MyBookStore.Pages.Books
{
    public partial class ManageBooks
    {
        [Inject]
        public IBookCatalog BookCatalog { get; set; } = default!;

        #region BookForm

        private EditContext? editContext;
        private FormAlert? FormAlert { get; set; }
        private List<string> errorList = new();
        private Result? result;
        private bool ShowBookForm;
        private string FormAddEditText = string.Empty;
        private string FormAddEditIcon = string.Empty;

        #endregion

        private Book selectedBook = new();
        private List<Book>? books;
        private Modal? Modal { get; set; }
        private Alert? MainAlert { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadBookData();

            editContext = new EditContext(selectedBook);
        }

        private async Task LoadBookData()
        {
            books = await BookCatalog.GetBooks();
        }
    }
}
