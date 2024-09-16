using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Controller.Data;
using WebPadaria.Data;
using WebPadaria.Models;

namespace WebPadaria.Pages.Compras
{
    public class IndexModel : PageModel
    {
        private readonly Bd_padaria _context;

        public IndexModel(Bd_padaria context)
        {
            _context = context;
        }

        public IList<Compra> Compras { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Compras = await _context.Compra
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .ToListAsync();
        }
    }
}
