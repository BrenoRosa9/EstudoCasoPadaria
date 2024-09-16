using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Controller.Data;
using WebPadaria.Models;

namespace WebPadaria.Pages.Compras
{
    public class DeleteModel : PageModel
    {
        private readonly Bd_padaria _context;

        public DeleteModel(Bd_padaria context)
        {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FirstOrDefaultAsync(m => m.Id_Compra == id);

            if (compra == null)
            {
                return NotFound();
            }
            else
            {
                Compra = compra;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                Compra = compra;
                _context.Compra.Remove(Compra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
