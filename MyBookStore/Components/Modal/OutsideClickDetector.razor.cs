using Microsoft.AspNetCore.Components;

namespace MyBookStore.Components.Modal
{
    public partial class OutsideClickDetector
    {
        [Parameter] 
        public int LowestInsideComponentZIndex { get; set; }
        [Parameter] 
        public bool TransparentOutside { get; set; } = true;
        [Parameter] 
        public EventCallback MethodToCallOnClick { get; set; }

        private async Task OnClick()
        {
            await MethodToCallOnClick.InvokeAsync(null);
        }
    }
}
