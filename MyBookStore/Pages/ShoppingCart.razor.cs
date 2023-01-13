using Microsoft.AspNetCore.Components;
using MyBookstore.Domain.DomainModels;

namespace MyBookStore.Pages
{
    public partial class ShoppingCart
    {
        [Inject]
        public Cart Cart { get; set; } = default!;
    }
}
