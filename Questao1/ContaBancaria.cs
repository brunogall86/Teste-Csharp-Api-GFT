using System;
using System.Globalization;

namespace Questao1
{
  
    public class ContaBancaria
    {
        private int numero;
        private string titular;
        private double depositoInicial;
        private double saldo;

        public ContaBancaria(int numero, string titular)
        {
            this.numero = numero;
            this.titular = titular;
            DepositoInicial(default(double));            
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            DepositoInicial(depositoInicial);            
        }

        private void DepositoInicial(double depositoInicial)
        {
            this.depositoInicial = depositoInicial;
            AtualizarSaldo(this.depositoInicial) ;
        }

        public void Deposito(double quantia)
        {
            if(quantia > default(double))
                AtualizarSaldo(quantia);
        }

        public void Saque(double quantia)
        {
            if(quantia > default(double))
            {
                AtualizarSaldo(quantia * -1);
                CobrarTaxaSaque();
            }
        }
        private void CobrarTaxaSaque()
        {
            AtualizarSaldo(TaxaSaque.ValorTaxa() * -1); 
        }

        private void AtualizarSaldo(double valor)
        {
            saldo += valor;
        }
        public void AtualizarNomeTitular(string nomeDotitular)
        {
            if (String.IsNullOrEmpty(nomeDotitular)) return;
            titular = nomeDotitular;
        }
        public override string ToString()
        {
            return $"Conta {numero}, Titular: {titular}, Saldo $ { saldo.ToString("0.00", new CultureInfo("en-US")) }";
        }
    }
}
