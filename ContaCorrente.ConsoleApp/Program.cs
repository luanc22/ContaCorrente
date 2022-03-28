using System;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario1 = new Funcionario("Luan");

            funcionario1.Salario = 12000;
            funcionario1.Aumento(10);

            ContaCorrente conta1 = new ContaCorrente();
            conta1.movimentacoes = new Movimentacoes[10];

            bool opcaoValida;

            conta1.Saque(100, out opcaoValida);

            conta1.Deposito(300);

            ContaCorrente conta2 = new ContaCorrente();
            conta2.movimentacoes = new Movimentacoes[10];

            conta2.Saque(200, out opcaoValida);

            conta1.TransferirPara(conta2, 400, out opcaoValida);

            conta1.ExibirDados();
            conta1.ExibirExtrato();
            conta2.ExibirDados();
            conta2.ExibirExtrato();


            Console.ReadLine();


        }
    }
}
