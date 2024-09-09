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

        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Produto Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Produto salvar(Produto item)
        {
            _produtos.Add(item);
            return item;
        }

        public Produto Save(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Produto Update(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}