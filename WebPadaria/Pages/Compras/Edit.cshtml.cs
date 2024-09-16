using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Controller.Data;
using WebPadaria.Models;

namespace WebPadaria.Pages.Compras
{
    public class EditModel : PageModel
    {
        private readonly Bd_padaria _context;

        public EditModel(Bd_padaria context)
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

            var compra =  await _context.Compra.FirstOrDefaultAsync(m => m.Id_Compra == id);
            if (compra == null)
            {
                return NotFound();
            }
            Compra = compra;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(Compra.Id_Compra))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.Id_Compra == id);
        }
    }
}
