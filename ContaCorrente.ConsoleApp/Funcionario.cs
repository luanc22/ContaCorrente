using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Funcionario
    {
        static int idTotal;

        private int id;
        private string nome;
        private string cpf;
        private string telefone;
        private string endereco;
        private double salario;

        public Funcionario()
        {
            idTotal++;
            id = idTotal;
        }

        public Funcionario(String nome)
        {
            this.nome = nome;
        }

        public string Cpf
        {
            get { return cpf; }
        }

        public string Telefone
        {
            get { return telefone; }
        }

        public string Endereco
        {
            get { return endereco; }
        }    
        public double Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        public void Aumento(int aumento)
        {
            aumento /= 100;

            salario = (salario * aumento) + salario;
        }

    }
}
