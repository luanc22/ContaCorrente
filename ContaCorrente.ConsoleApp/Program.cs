using System;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();
            conta1.saldoDaConta = 1000;
            conta1.idDaConta = 1;
            conta1.limiteConta = 0;
            conta1.contaEspecial = false;
            conta1.movimentacoes = new Movimentacoes[10];

            bool opcaoValida;

            conta1.Saque(100, out opcaoValida);

            conta1.Deposito(300);

            ContaCorrente conta2 = new ContaCorrente();
            conta2.saldoDaConta = 800;
            conta2.idDaConta = 2;
            conta2.limiteConta = 0;
            conta2.contaEspecial = false;
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
