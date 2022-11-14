using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace MyBookStore.Components
{
    public partial class FormAlert
    {

        [Parameter]
        public EditContext? EditContext { get; set; }

        [Parameter]
        public List<string> ErrorList { get; set; } = new();

        [Parameter]
        public bool formSucces { get; set; }

        private Alert? Alert { get; set; }
        private string alertStyle = string.Empty;


        protected override void OnParametersSet()
        {
            if (formSucces)
            {
                alertStyle = "alert-success";
            }
            else
            {
                alertStyle = "alert-danger";
            }
        }

        public void Show()
        {
            Alert?.Show();
        }
        public void Close()
        {
            Alert?.Close();
        }
    }
}
