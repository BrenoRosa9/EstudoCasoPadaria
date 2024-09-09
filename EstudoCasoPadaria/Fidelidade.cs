using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    internal class Fidelidade : Cliente
    {
        public int Pontuacao { get; private set; }

        public Fidelidade(string nome, string cpf, string email) : base(nome, cpf, email)
        {
            Pontuacao = 0;
        }

        public void ComputarPontos(int valorVenda)
        {
            Pontuacao += valorVenda / 10; 
        }
    }
}