using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCasoPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Produto pao = new Produto("Pão", 5.00m);
                Produto queijo = new Produto("Queijo", 150.00m);

                //Implementando clientes 1 e 2, 3 não é cadastrado
                Fidelidade clienteFidelidade = new Fidelidade("João", "12345678901", "Carlo");
                Fidelidade clienteFidelidade1 = new Fidelidade("Pedro", "12345678901", "Carlos");

                //Compra de clientes cadastrados e geração do cupom
                VendaComum venda = new VendaComum(pao, "Dinheiro", 5, 1, clienteFidelidade);
                string cupom = venda.GerarCupom();
                Console.WriteLine(cupom);
                Console.WriteLine($"Pontos do cliente: {clienteFidelidade.Pontuacao}");

                VendaComum venda1 = new VendaComum(queijo, "Dinheiro", 50, 1, clienteFidelidade);
                string cupom1 = venda1.GerarCupom();
                Console.WriteLine(cupom1);
                Console.WriteLine($"Pontos do cliente: {clienteFidelidade.Pontuacao}");

                VendaComum venda2 = new VendaComum(pao, "Dinheiro", 800, 1, clienteFidelidade1);
                string cupom2 = venda2.GerarCupom();
                Console.WriteLine(cupom2);
                Console.WriteLine($"Pontos do cliente: {clienteFidelidade1.Pontuacao}");

                //Compra de cliente não cadastrado não gera cupom
                VendaComum venda3 = new VendaComum(pao, "Dinheiro", 800, 1);
                string cupom3 = venda3.GerarCupom();
                Console.WriteLine(cupom3);
                
                Console.ReadKey();


            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Erro ao processar a venda: {ex.Message}");
            }
        }
    }
}
