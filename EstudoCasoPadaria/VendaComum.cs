using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    public class VendaComum : Venda
    {
        public Produto Produto { get; private set; }
        public Cliente Cliente { get; private set; }

        public VendaComum(Produto produto, string formaDePagamento, int valorTotal, int id, Cliente cliente = null)
            : base(valorTotal, formaDePagamento, id)
        {
            Produto = produto;
            Cliente = cliente;
            FormaPagamento = formaDePagamento;
            ValorTotal = valorTotal;

            if (cliente != null && cliente is Fidelidade)
            {
                ((Fidelidade)cliente).ComputarPontos(valorTotal);
            }
        }

        public override string GerarCupom()
        {
            string cupom = $"ID: {id}, Produto: {Produto.Nome}, Valor: {ValorTotal:C}, Pagamento: {FormaPagamento}";

            if (Cliente != null)
            {
                cupom += $", Cliente: {Cliente.nome}, CPF: {Cliente.cpf}";
            }

            return cupom;
        }
    }
}
