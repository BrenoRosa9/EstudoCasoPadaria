using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Data;
using WebPadaria.Models;
using System.Linq;
using System.Threading.Tasks;
using WebPadaria.Controller.Data;

namespace WebPadaria.Pages.Compras
{
    public class CreateModel : PageModel
    {
        private readonly Bd_padaria _context;

        public CreateModel(Bd_padaria context)
        {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; }
        public SelectList Clientes { get; set; }
        public SelectList Produtos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Clientes = new SelectList(await _context.Cliente.ToListAsync(), "Id", "Nome");
            Produtos = new SelectList(await _context.Produto.Select(p => new SelectListItem
            {
                Value = p.Id_Produto.ToString(),
                Text = p.Nome_Produto
            }).ToListAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var produto = await _context.Produto.FindAsync(Compra.Produto_Id);
            Compra.Valor_Total = produto.Valor_Produto * Compra.Quantidade;

            _context.Compra.Add(Compra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
