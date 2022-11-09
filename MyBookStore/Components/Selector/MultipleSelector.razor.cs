using Microsoft.AspNetCore.Components;

namespace MyBookStore.Components.Selector
{
    public partial class MultipleSelector<T> where T : class
    {
        [Parameter]
        public List<T> UnSelected { get; set; } = new();
        [Parameter]
        public List<T> Selected { get; set; } = new();
        [Parameter]
        public string Selector { get; set; } = string.Empty;
        [Parameter]
        public string Label { get; set; } = string.Empty;

        private void Select(T item)
        {
            UnSelected.Remove(item);
            Selected.Add(item);
        }

        private void Deselect(T item)
        {
            UnSelected.Add(item);
            Selected.Remove(item);
        }

        private void SelectAll()
        {
            Selected.AddRange(UnSelected);
            UnSelected.Clear();
        }

        private void DeselectAll()
        {
            UnSelected.AddRange(Selected);
            Selected.Clear();
        }
    }
}
