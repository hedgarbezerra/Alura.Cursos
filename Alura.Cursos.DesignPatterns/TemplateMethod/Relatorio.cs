using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.TemplateMethod
{
    class Banco
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Conta> Contas { get; set; }
    }
    class Conta
    {
        public Conta() {}
        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
        }
        public Conta(string titular, double saldo, string agencia, long numero) : this(titular, saldo)
        {
            Agencia = agencia;
            Numero = numero;
        }

        public string Titular { get; set; }
        public double Saldo { get; set; }
        public string Agencia { get; set; }
        public long Numero { get; set; }
    }
    abstract class Relatorio
    {
        public string Rodape { get; protected set; }
        public string Cabecalho { get; protected set; }
        public string Corpo { get; protected set; }

        public void Imprimir(Banco b)
        {
            GerarConteudo(b);
            MostrarConteudo();
        }
        protected abstract void GerarConteudo(Banco b);
        private void MostrarConteudo()
        {
            Console.WriteLine(Cabecalho);
            Console.WriteLine(Corpo);
            Console.WriteLine(Rodape);
        }
    }

    class RelatorioSimples : Relatorio
    {
        protected override void GerarConteudo(Banco b)
        {
            Cabecalho = $"{b.Nome} - {b.Telefone}";
            Rodape = $"{b.Nome} - {b.Telefone}";
            Corpo = string.Join(",", b.Contas.Select(c => $"Titular: {c.Titular} - {c.Saldo} \n"));
        }
    }

    class RelatorioComplexo : Relatorio
    {
        protected override void GerarConteudo(Banco b)
        {
            Cabecalho = $"{b.Nome} em {b.Endereco} - {b.Telefone}";
            Rodape = $"{b.Email} - {DateTime.Now.ToString("dd/MM/yyyy")}";
            Corpo = string.Join(",", b.Contas.Select(c => $"Conta: {c.Numero} - Titular: {c.Titular} - AG: {c.Agencia} {c.Saldo}  \n"));
        }
    }

}
