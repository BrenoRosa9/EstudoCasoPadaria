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
        public Compra Compra { get; set; } = default!;

        public SelectList Clientes { get; set; } = default!;
        public SelectList Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Carregar clientes e produtos para os dropdowns
            var clientes = await _context.Cliente.ToListAsync();
            var produtos = await _context.Produto.ToListAsync();

            Clientes = new SelectList(clientes, "Id", "Nome");
            Produtos = new SelectList(produtos.Select(p => new SelectListItem
            {
                Value = p.Id_Produto.ToString(),
                Text = $"{p.Nome_Produto} - {p.Valor_Produto.ToString("0.00")}"
            }).ToList(), "Value", "Text");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Encontrar o produto selecionado
            var produto = await _context.Produto.FindAsync(Compra.Produto_Id);
            if (produto == null)
            {
                return NotFound();
            }

            // Calcular o valor total
            Compra.Valor_Total = produto.Valor_Produto * Compra.Quantidade;

            // Adicionar a compra ao contexto
            _context.Compra.Add(Compra);

            // Atualizar a pontuação do cliente
            var cliente = await _context.Cliente.FindAsync(Compra.Cliente_Id);
            if (cliente == null)
            {
                return NotFound();
            }

            int pontosAdicionados = (int)(Compra.Valor_Total / 10);
            int pontuacaoAtual = string.IsNullOrEmpty(cliente.Pontuacao) ? 0 : int.Parse(cliente.Pontuacao);
            cliente.Pontuacao = (pontuacaoAtual + pontosAdicionados).ToString();

            // Atualizar o cliente no contexto
            _context.Cliente.Update(cliente);

            // Salvar as alterações no banco de dados
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
