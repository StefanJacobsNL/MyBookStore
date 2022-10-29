using Microsoft.AspNetCore.Components;

namespace MyBookStore.Components
{
    public partial class Alert
    {
        [Parameter]
        public List<string> AlertList { get; set; } = new();
        [Parameter]
        public string AlertCssStyle { get; set; } = string.Empty;
        [Parameter] 
        public string AlertText { get; set; } = string.Empty;
        [Parameter] 
        public string Icon { get; set; } = string.Empty;
        [Parameter]
        public RenderFragment? CustomTextElement { get; set; }

        private bool showAlert;

        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(AlertCssStyle))
            {
                AlertCssStyle += "alert-success";
            }
        }

        public void Show()
        {
            showAlert = true;
        }

        public void Close()
        {
            showAlert = false;
        }
    }
}
