using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.State
{
    class Conta
    {
        public Conta() { }
        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
            Estado = new EstadoContaPositiva();
        }
        public Conta(string titular, double saldo, string agencia, long numero, DateTime dataCriacao) : this(titular, saldo)
        {
            Agencia = agencia;
            Numero = numero;
            DataCriacao = dataCriacao;
        }

        public string Titular { get; set; }
        public double Saldo { get; set; }
        public string Agencia { get; set; }
        public long Numero { get; set; }
        public DateTime DataCriacao { get; set; }
        public IEstadoConta Estado { get; set; }

        public void Saca(double valor)
        {
            Estado.Saca(this, valor);
        }

        public void Deposita(double valor)
        {
            Estado.Deposita(this, valor);
        }
    }

    interface IEstadoConta
    {
        public string Nome { get; }
        void Saca(Conta conta, double valor);
        void Deposita(Conta conta, double valor);
    }

    class EstadoContaPositiva : IEstadoConta
    {
        public string Nome => "Positiva";

        public void Saca(Conta conta, double valor)
        {
            conta.Saldo -= valor;

            if (conta.Saldo < 0)
                conta.Estado = new EstadoContaNegativa();
        }

        public void Deposita(Conta conta, double valor)
        {
            conta.Saldo += valor * 0.98;
        }
    }
    class EstadoContaNegativa : IEstadoConta
    {
        public string Nome => "Negativa";

        public void Saca(Conta conta, double valor)
        {
            throw new Exception("Sua conta está no vermelho. Não é possível sacar!");
        }

        public void Deposita(Conta conta, double valor)
        {
            conta.Saldo += valor * 0.95;
            if (conta.Saldo > 0)
                conta.Estado = new EstadoContaPositiva();
        }

    }
}
