using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    internal class RepositorioProduto : IRepositorio<Produto, long>
    {
        private List<Produto> _produtos = new List<Produto>();

        public IEnumerable<Produto> consultar()
        {
            return _produtos;
        }

        public Produto salvar(Produto item)
        {
            _produtos.Add(item);
            return item;
        }

    }
}