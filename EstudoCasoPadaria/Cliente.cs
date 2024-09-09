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

        public Cliente(string nome, string cpf)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Cpf = Cpf;
        }

        public void AdicionarCliente()
        {
            Console.WriteLine($"Cliente: {Nome}, CPF: {Cpf}, Email:{Email}  ");
        }
    }
}
