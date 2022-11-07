using Microsoft.AspNetCore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Components;
using MyBookstore.Domain.DomainModels;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;
using MyBookStore.Helper;

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

        private void OnAddBtnClick()
        {
            FormAddEditText = "Add";
            FormAddEditIcon = IconStrings.AddIcon;
            selectedBook = new();
            editContext = new EditContext(selectedBook);
            ShowBookForm = true;
        }

        private void OnEditBtnListClick(Book book)
        {
            FormAddEditIcon = IconStrings.EditIcon;
            FormAddEditText = "Edit";
            selectedBook = book;
            editContext = new EditContext(selectedBook);
            ShowBookForm = true;
        }

        private void OnDeleteBtnListClick(Book book)
        {
            selectedBook = book;
            ShowBookForm = false;
            Modal?.Show();
        }

        private async Task OnValidSubmit()
        {
            MainAlert?.Close();
            result = Result.Reset();
            FormAlert?.Close();
            errorList.Clear();

            if (editContext != null && editContext.Validate() && editContext.IsModified())
            {
                if (selectedBook.Id > 0)
                {
                    //result = await BookCatalog.Updatebook(selectedBook);
                }
                else
                {
                    //result = await BookCatalog.AddBook(selectedBook);
                }

                errorList.Add(result.Error);

                FormAlert?.Show();
                await LoadBookData();
            }
            else
            {
                errorList.Add("No changes found");
                FormAlert?.Show();
            }
        }

        private void OnInvalidSubmit()
        {
            errorList.Clear();
            FormAlert?.Show();
        }

        private async Task OnModalDeleteConfirm()
        {
            result = Result.Reset();

            result = await BookCatalog.DeleteAuthor(selectedBook.Id);

            errorList.Clear();
            errorList.Add(result.Error);
            MainAlert?.Show();
            Modal?.Close();
            await LoadBookData();
        }
    }
}
