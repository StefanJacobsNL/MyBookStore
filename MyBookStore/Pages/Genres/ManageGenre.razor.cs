﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Database;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Model;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.DomainModels;
using MyBookStore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Helper;

namespace MyBookStore.Pages.Genres
{
    public partial class ManageGenre
    {
        [Inject]
        public IBookRepository BookRepository { get; set; } = default!;

        #region GenreForm

        private EditContext? editContext;
        private FormAlert? FormAlert { get; set; }
        private List<string> errorList = new();
        private Result? result;
        private bool ShowGenreForm;
        private string FormAddEditText = string.Empty;
        private string FormAddEditIcon = string.Empty;

        #endregion

        private Genre selectedGenre = new();

        private List<Genre>? genres;
        private Modal? Modal { get; set; }
        private Alert? MainAlert { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadGenreData();

            editContext = new EditContext(selectedGenre);
        }

        private async Task LoadGenreData()
        {
            genres = await BookRepository.GetGenres();
        }

        private void OnAddBtnClick()
        {
            FormAddEditText = "Add";
            FormAddEditIcon = IconStrings.AddIcon;
            selectedGenre = new();
            editContext = new EditContext(selectedGenre);
            ShowGenreForm = true;
        }

        private void OnEditBtnListClick(Genre genre)
        {
            FormAddEditIcon = IconStrings.EditIcon;
            FormAddEditText = "Edit";
            selectedGenre = genre;
            editContext = new EditContext(selectedGenre);
            ShowGenreForm = true;
        }

        private void OnDeleteBtnListClick(Genre genre)
        {
            selectedGenre = genre;
            ShowGenreForm = false;
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
                if (selectedGenre.Id > 0)
                {
                    result = await BookRepository.UpdateGenre(selectedGenre);
                }
                else
                {
                    result = await BookRepository.AddGenre(selectedGenre);
                }

                errorList.Add(result.Error);

                FormAlert?.Show();
                await LoadGenreData();
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

            result = await BookRepository.DeleteGenre(selectedGenre.Id);

            errorList.Clear();
            errorList.Add(result.Error);
            MainAlert?.Show();
            Modal?.Close();
            await LoadGenreData();
        }
    }
}
