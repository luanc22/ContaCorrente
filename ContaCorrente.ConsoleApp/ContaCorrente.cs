using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    public class Movimentacoes
    {
        public double valorMovimentacao;
        public string debitoOuCredito;
    }

    public class ContaCorrente
    {
        static int idTotal;
        private int idDaConta;

        private double saldoDaConta;
        private double limiteConta;
        
        private bool contaEspecial;
        private int posicalAtualExtrato = 0;

        public Movimentacoes[] movimentacoes;

        public ContaCorrente()
        {
            idTotal++;
            this.idDaConta = idTotal;
            this.saldoDaConta = 0;
            this.limiteConta = 200;
            this.contaEspecial = false;
        }

        #region Metodos
        public bool Saque(double valorSaque, out bool opcaoValida)
        {
            if (valorSaque > saldoDaConta + limiteConta)
            {
                opcaoValida = false;
                return opcaoValida;
            }
            else
            {
                if (saldoDaConta > valorSaque)
                {
                    saldoDaConta = saldoDaConta - valorSaque;
                    opcaoValida = true;

                    Movimentacoes movimentacao = new Movimentacoes();
                    movimentacao.valorMovimentacao = valorSaque;
                    movimentacao.debitoOuCredito = "Debito";
                    movimentacoes[posicalAtualExtrato] = movimentacao;

                    posicalAtualExtrato++;
                    return opcaoValida;
                }
                else
                {
                    double valorRest;
                    valorRest = valorSaque - saldoDaConta;
                    saldoDaConta = 0;
                    limiteConta = limiteConta - valorRest;
                    opcaoValida = true;

                    Movimentacoes movimentacao = new Movimentacoes();
                    movimentacao.valorMovimentacao = valorSaque;
                    movimentacao.debitoOuCredito = "Debito";
                    movimentacoes[posicalAtualExtrato] = movimentacao;

                    posicalAtualExtrato++;
                    return opcaoValida;
                }
            }

        }

        public double Deposito(double valorDeposito)
        {
            Movimentacoes movimentacao = new Movimentacoes();
            movimentacao.valorMovimentacao = valorDeposito;
            movimentacao.debitoOuCredito = "Credito";
            movimentacoes[posicalAtualExtrato] = movimentacao;

            posicalAtualExtrato++;
            saldoDaConta = saldoDaConta + valorDeposito;
            return saldoDaConta;
        }

        public void ExibirDados()
        {
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("Dados da conta {0}.", idDaConta);
            Console.WriteLine();
            Console.WriteLine("Saldo da conta: {0}.", saldoDaConta);

            if (contaEspecial == true)
            {
                Console.WriteLine("Conta especial: Sim");
            }
            else
            {
                Console.WriteLine("Conta especial: Nao");
            }

            Console.WriteLine("Limite da conta: {0}.", limiteConta);
            Console.WriteLine();
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("Extrato da conta {0}.", idDaConta);
            Console.WriteLine();

            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Valor movimentado: {0}", movimentacoes[i].valorMovimentacao);
                    Console.WriteLine("Tipo de movimentacao: {0}", movimentacoes[i].debitoOuCredito);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        public bool TransferirPara(ContaCorrente contaPassada, double valorTransferencia, out bool opcaoValida)
        {
            Movimentacoes movimentacao = new Movimentacoes();
            Movimentacoes movimentacaoPraOutraConta = new Movimentacoes();

            if (valorTransferencia > saldoDaConta + limiteConta)
            {
                opcaoValida = false;
                return opcaoValida;
            }
            else
            {
                if (saldoDaConta > valorTransferencia)
                {
                    saldoDaConta = saldoDaConta - valorTransferencia;
                    opcaoValida = true;


                    contaPassada.saldoDaConta = contaPassada.saldoDaConta + valorTransferencia;

                    movimentacao.valorMovimentacao = valorTransferencia;
                    movimentacao.debitoOuCredito = "Debito (Transferencia)";
                    movimentacoes[posicalAtualExtrato] = movimentacao;

                    movimentacaoPraOutraConta.valorMovimentacao = valorTransferencia;
                    movimentacaoPraOutraConta.debitoOuCredito = "Credito (Transferencia)";

                    contaPassada.movimentacoes[contaPassada.posicalAtualExtrato] = movimentacaoPraOutraConta;                 

                    posicalAtualExtrato++;
                    return opcaoValida;
                }
                else
                {
                    double valorRest;
                    valorRest = valorTransferencia - saldoDaConta;
                    saldoDaConta = 0;
                    limiteConta = limiteConta - valorRest;
                    opcaoValida = true;

                    contaPassada.saldoDaConta = contaPassada.saldoDaConta + valorTransferencia;

                    movimentacao.valorMovimentacao = valorTransferencia;
                    movimentacao.debitoOuCredito = "Debito (Transferencia)";
                    movimentacoes[posicalAtualExtrato] = movimentacao;

                    movimentacaoPraOutraConta.valorMovimentacao = valorTransferencia;
                    movimentacaoPraOutraConta.debitoOuCredito = "Credito (Transferencia)";

                    contaPassada.movimentacoes[contaPassada.posicalAtualExtrato] = movimentacaoPraOutraConta;

                    posicalAtualExtrato++;
                    return opcaoValida;
                }
            }
        }
        #endregion
    }
}
