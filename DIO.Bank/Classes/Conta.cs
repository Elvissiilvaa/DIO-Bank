using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; } // USando Enum para aplicar a referencia
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }

        public bool Sacar(double valorSaque)
        {
            // validando se o saldo é o suficiente. 

            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficente");
                return false;
            }
            // Dica de formatação no link a Seguir: 
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("O saldo atual da conta é de {0} e {1}  ", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("O saldo atual da conta é de {0} e {1}  ", this.Nome, this.Saldo);
        }

        public void Tranferir(double valorTransferencia, Conta contaDestino)
        {

            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);

            }

        }

         public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}

    }

}


