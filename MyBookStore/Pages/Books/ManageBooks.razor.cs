using Microsoft.AspNetCore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Components;
using MyBookstore.Domain.DomainModels;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;
using MyBookStore.Helper;
using System.IO;
using MyBookStore.Components.Selector;
using static System.Reflection.Metadata.BlobBuilder;
using MyBookstore.Domain.Comparators;

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

        #region Select Genres

        private List<Genre> AllGenres = new();
        private List<Genre> UnSelectedGenres = new();

        #endregion

        private List<Author> AllAuthors = new();
        private List<Author> UnSelectedAuthors = new();

        #endregion

        private Book selectedBook = new();
        private List<Book>? books;
        private Modal? Modal { get; set; }
        private Alert? MainAlert { get; set; }
        private readonly string uploadPath = "wwwroot/img/bookcover";

        protected async override Task OnInitializedAsync()
        {
            await LoadBookData();

            editContext = new EditContext(selectedBook);
        }

        private async Task LoadBookData()
        {
            selectedBook = new();
            books = await BookCatalog.GetBooks();
            books.Sort(new BookNameComparator());

            AllAuthors = await BookCatalog.GetAuthors();
            AllGenres = await BookCatalog.GetGenres();
        }

        private void OnAddBtnClick()
        {
            FormAddEditText = "Add";
            FormAddEditIcon = IconStrings.Add;
            selectedBook = new();
            editContext = new EditContext(selectedBook);
            ShowBookForm = true;

            UnSelectedGenres = AllGenres;
            selectedBook.Genres = new();

            UnSelectedAuthors = AllAuthors;
            selectedBook.Authors = new();
        }

        private void OnEditBtnListClick(Book book)
        {
            FormAddEditIcon = IconStrings.Edit;
            FormAddEditText = "Edit";
            selectedBook = book;
            editContext = new EditContext(selectedBook);
            ShowBookForm = true;

            var getAllGenreNames = selectedBook.Genres.Select(x => x.Name).ToList();
            var getAllAuthorNames = selectedBook.Authors.Select(x => x.Name).ToList();

            UnSelectedGenres = AllGenres.Where(x => !getAllGenreNames.Contains(x.Name)).ToList();
            UnSelectedAuthors = AllAuthors.Where(x => !getAllAuthorNames.Contains(x.Name)).ToList();
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
                CheckIfListsAreValid();

                if (!errorList.Any())
                {
                    if (selectedBook.Id > 0)
                    {
                        result = await BookCatalog.UpdateBook(selectedBook);
                    }
                    else
                    {
                        result = await BookCatalog.AddBook(selectedBook);
                    }

                    if (selectedBook.FileUpload != null)
                    {
                        var getFileExtension = selectedBook.FileUpload.Name.Split('.')[1];
                        selectedBook.ImagePath = Path.Combine(uploadPath, $"{selectedBook.Name}.{getFileExtension}");

                        await using FileStream fs = new(selectedBook.ImagePath, FileMode.Create);
                        await selectedBook.FileUpload.OpenReadStream().CopyToAsync(fs);
                    }

                    errorList.Add(result.Error);

                    FormAlert?.Show();

                    if (result.Succes)
                    {
                        await LoadBookData();
                    }
                }
                else
                {
                    FormAlert?.Show();
                }
            }
            else
            {
                errorList.Add("No changes found");
                FormAlert?.Show();
            }
        }

        /// <summary>
        /// Checks the added Genres and Authors of the book
        /// </summary>
        private void CheckIfListsAreValid()
        {
            if (!selectedBook.CheckIfBookHasGenres())
            {
                errorList.Add("No added genres");
            }

            if (!selectedBook.CheckIfBookHasAuthors())
            {
                errorList.Add("No added authors");
            }
        }

        private void OnInvalidSubmit()
        {
            errorList.Clear();
            FormAlert?.Show();
        }

        private void SetUploadBook(InputFileChangeEventArgs e)
        {
            selectedBook.FileUpload = e.File;
            selectedBook.ImagePath = e.File.Name;
        }

        private async Task OnModalDeleteConfirm()
        {
            result = Result.Reset();

            result = await BookCatalog.DeleteBook(selectedBook.Id);

            errorList.Clear();
            errorList.Add(result.Error);
            MainAlert?.Show();
            Modal?.Close();
            await LoadBookData();
        }
    }
}
