using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    public class Produto
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
