using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;
using MyBookStore.Components;
using MyBookStore.Components.Modal;
using MyBookStore.Helper;

namespace MyBookStore.Pages.Books
{
    public partial class ManageWarehouse
    {
        [Inject]
        public IBookCatalog BookCatalog { get; set; } = default!;

        #region WarehouseForm

        private EditContext? editContext;
        private FormAlert? FormAlert { get; set; }
        private List<string> errorList = new();
        private Result? result;
        private bool ShowWarehouseForm;
        private string FormAddEditText = string.Empty;
        private string FormAddEditIcon = string.Empty;

        #endregion

        private Warehouse selectedWarehouse = new();

        private List<Warehouse>? warehouses;
        private Modal? Modal { get; set; }
        private Alert? MainAlert { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadWarehouseData();

            editContext = new EditContext(selectedWarehouse);
        }

        private async Task LoadWarehouseData()
        {
            warehouses = await BookCatalog.GetWarehouses();
        }

        private void OnAddBtnClick()
        {
            FormAddEditText = "Add";
            FormAddEditIcon = IconStrings.Add;
            selectedWarehouse = new();
            editContext = new EditContext(selectedWarehouse);
            ShowWarehouseForm = true;
        }

        private void OnEditBtnListClick(Warehouse warehouse)
        {
            FormAddEditIcon = IconStrings.Edit;
            FormAddEditText = "Edit";
            selectedWarehouse = warehouse;
            editContext = new EditContext(selectedWarehouse);
            ShowWarehouseForm = true;
        }

        private void OnDeleteBtnListClick(Warehouse warehouse)
        {
            selectedWarehouse = warehouse;
            ShowWarehouseForm = false;
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
                if (selectedWarehouse.Id > 0)
                {
                    result = await BookCatalog.UpdateWarehouse(selectedWarehouse);
                }
                else
                {
                    result = await BookCatalog.AddWarehouse(selectedWarehouse);
                }

                errorList.Add(result.Error);

                FormAlert?.Show();
                await LoadWarehouseData();
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

            result = await BookCatalog.DeleteWarehouse(selectedWarehouse.Id);

            errorList.Clear();
            errorList.Add(result.Error);
            MainAlert?.Show();
            Modal?.Close();
            await LoadWarehouseData();
        }
    }
}
