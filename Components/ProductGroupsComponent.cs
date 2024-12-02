using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NeoStore.Data;

namespace NeoStore.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private EshopContext _context { get; set; }

        public ProductGroupsComponent(EshopContext context)
        {
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml", _context.Categories);
        }

    }
}
