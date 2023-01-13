using Microsoft.AspNetCore.Components;
using MyBookstore.Domain.DomainModels;

namespace MyBookStore.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public Cart Cart { get; set; } = default!;

        private bool collapseNavMenu = true;
        private bool collapseAdminMenu;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override void OnInitialized()
        {
            if (NavigationManager.Uri.ToLower().Contains("admin"))
            {
                collapseAdminMenu = true;
            }
        }

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void ToggleAdminDropDown()
        {
            collapseAdminMenu = !collapseAdminMenu;
        }
    }
}
