using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    public abstract class Venda
    {

        public int id { get; set; }
        public int ValorTotal { get; set; }
        public string FormaPagamento { get; set; }

        public Venda(int valorTotal, string formaDePagamento, int id)
        {
            ValorTotal = ValorTotal;
            formaDePagamento = formaDePagamento;
            id = id;

        }
        public abstract string GerarCupom();
    }
}
