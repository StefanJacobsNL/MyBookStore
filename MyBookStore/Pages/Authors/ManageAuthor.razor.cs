using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Database.Model;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.DomainModels;
using MyBookStore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Helper;

namespace MyBookStore.Pages.Authors
{
    public partial class ManageAuthor
    {
        [Inject]
        public IBookRepository BookRepository { get; set; } = default!;

        #region GenreForm

        private EditContext? editContext;
        private FormAlert? FormAlert { get; set; }
        private List<string> errorList = new();
        private Result? result;
        private bool ShowAuthorForm;
        private string FormAddEditText = string.Empty;
        private string FormAddEditIcon = string.Empty;

        #endregion

        private Author selectedAuthor = new();
        private List<Author>? authors;
        private Modal? Modal { get; set; }
        private Alert? MainAlert { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadAuthorData();

            editContext = new EditContext(selectedAuthor);
        }

        private async Task LoadAuthorData()
        {
            authors = await BookRepository.GetAuthors();
        }

        private void OnAddBtnClick()
        {
            FormAddEditText = "Add";
            FormAddEditIcon = IconStrings.AddIcon;
            selectedAuthor = new();
            editContext = new EditContext(selectedAuthor);
            ShowAuthorForm = true;
        }

        private void OnEditBtnListClick(Author author)
        {
            FormAddEditIcon = IconStrings.EditIcon;
            FormAddEditText = "Edit";
            selectedAuthor = author;
            editContext = new EditContext(selectedAuthor);
            ShowAuthorForm = true;
        }

        private void OnDeleteBtnListClick(Author author)
        {
            selectedAuthor = author;
            ShowAuthorForm = false;
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
                if (selectedAuthor.Id > 0)
                {
                    result = await BookRepository.UpdateAuthor(selectedAuthor);
                }
                else
                {
                    result = await BookRepository.AddAuthor(selectedAuthor);
                }

                errorList.Add(result.Error);

                FormAlert?.Show();
                await LoadAuthorData();
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

            result = await BookRepository.DeleteAuthor(selectedAuthor.Id);

            errorList.Clear();
            errorList.Add(result.Error);
            MainAlert?.Show();
            Modal?.Close();
            await LoadAuthorData();
        }
    }
}
