using System;

namespace EstudoCasoPadaria
{
    public class Cliente
    {
        private string _cpf; 
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (value.Length != 11)
                {
                    throw new Exception("CPF INVÁLIDO"); 
                }
                _cpf = value; 
            }
        }

        public Cliente(string nome, string cpf, string email)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
        }

        public void AdicionarCliente()
        {
            Console.WriteLine($"Cliente: {Nome}, CPF: {Cpf}, Email: {Email}");
        }
    }
}
