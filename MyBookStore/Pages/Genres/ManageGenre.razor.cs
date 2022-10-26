using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Database;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Model;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain;
using MyBookStore.Components;

namespace MyBookStore.Pages.Genres
{
    public partial class ManageGenre
    {
        [Inject]
        public IBookRepository bookRepository { get; set; } = default!;

        private FormAlert? FormAlert { get; set; }
        private List<string> errorList = new();
        private Result? result;

        private Genre genre = new();
        private EditContext? editContext;
        private string alertStyle = string.Empty;

        protected override void OnInitialized()
        {
            editContext = new EditContext(genre);
        }

        private async Task OnValidSubmit()
        {
            result = Result.Reset();
            FormAlert?.Close();
            errorList.Clear();

            if (editContext != null && editContext.Validate() && editContext.IsModified())
            {
                result = await bookRepository.AddGenre(genre);

                errorList.Add(result.Error);

                FormAlert?.Show();
            }
        }

        private void OnInvalidSubmit()
        {
            errorList.Clear();
            FormAlert?.Show();
        }
    }
}
