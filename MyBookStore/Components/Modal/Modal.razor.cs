using Microsoft.AspNetCore.Components;

namespace MyBookStore.Components.Modal
{
    public partial class Modal
    {
        [Parameter] 
        public EventCallback OnConfirmMethod { get; set; }
        [Parameter] 
        public string HeaderText { get; set; } = string.Empty;
        [Parameter] 
        public string BodyText { get; set; } = string.Empty;
        [Parameter] 
        public string BtnConfirmTxt { get; set; } = string.Empty;
        [Parameter] 
        public string BtnConfirmColour { get; set; } = "primary";
        [Parameter]
        public string BtnConfirmIcon { get; set; } = string.Empty;

        private string ModalDisplay = "none;";
        private string ModalClass = "";
        private bool ShowBackdrop = false;

        public void Show()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        private void InvokeParentMethod()
        {
            OnConfirmMethod.InvokeAsync();
        }
    }
}
