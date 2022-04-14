using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Decorator
{
    class Conta
    {
        public Conta() { }
        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
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
    }
    abstract class Filtro
    {
        public Filtro(Filtro proximo = null)
        {
            ProximoFiltro = proximo;
        }
        public Filtro ProximoFiltro { get; protected set; }
        public IList<Conta> Filtrar(IList<Conta> contas)
        {
            var contasFiltradas = ContasFiltradas(contas);

            return ProximoFiltro is null ? contasFiltradas : contasFiltradas.Concat(ProximoFiltro.Filtrar(contas).Where(c => !contasFiltradas.Contains(c))).ToList();
        }
        protected abstract IList<Conta> ContasFiltradas(IList<Conta> contas);
    }

    class FiltroSaldoMenor100 : Filtro
    {
        public FiltroSaldoMenor100(Filtro proximo = null) : base(proximo)
        {
        }

        protected override IList<Conta> ContasFiltradas(IList<Conta> contas) => contas.Where(c => c.Saldo < 100).ToList();
    }
    class FiltroSaldoMaior500 : Filtro
    {
        public FiltroSaldoMaior500(Filtro proximo = null) : base(proximo)
        {
        }

        protected override IList<Conta> ContasFiltradas(IList<Conta> contas) => contas.Where(c => c.Saldo > 500).ToList();
    }

    class FiltroSaldoMesCriacao : Filtro
    {
        public FiltroSaldoMesCriacao(Filtro proximo = null) : base(proximo)
        {
        }

        protected override IList<Conta> ContasFiltradas(IList<Conta> contas) => contas.Where(c => (DateTime.Today.Date.AddMonths(-1) - c.DataCriacao.Date).Days < 30).ToList();
        
        //(c.DataCriacao - DateTime.Today.Date).Days > 30).ToList();
    }

    class FiltragemContasFlagadas
    {
        public IList<Conta> ContasFlagadas(IList<Conta> contas)
        {
            var filtros = new FiltroSaldoMenor100(new FiltroSaldoMaior500(new FiltroSaldoMesCriacao()));

            return filtros.Filtrar(contas);
        }
    }
}
