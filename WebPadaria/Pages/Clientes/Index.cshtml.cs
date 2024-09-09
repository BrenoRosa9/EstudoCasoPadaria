using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Data;
using WebPadaria.Models;

namespace WebPadaria.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly WebPadaria.Data.Bd_padaria _context;

        public IndexModel(WebPadaria.Data.Bd_padaria context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Cliente.ToListAsync();
        }
    }
}
