using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility.Descontos
{
    internal class Item
    {
        public Item()
        {
        }
        public Item(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; set; }
        public double Valor { get; set; }
    }
    internal class Orcamento
    {
        public double Valor { get => Itens.Sum(i => i.Valor); }
        public List<Item> Itens { get; set; }
    }

    internal abstract class Desconto : ICadeia<double>
    {
        public ICadeia<double> Proximo { get; private set; }
        public void DefinirProximo(ICadeia<double> proximo) => this.Proximo = proximo;
        public abstract double Lidar(params object[] parametros);
    }
    internal class DescontoMaisCincoItens : Desconto
    {
        public override double Lidar(params object[] parametros)
        {
            var orcamento = parametros.FirstOrDefault() as Orcamento;
            if (orcamento.Itens.Count > 5)
                return orcamento.Valor * 0.05;

            return Proximo is null ? 0 : Proximo.Lidar(parametros);
        }
    }
    internal class DescontoValorMaior500 : Desconto
    {
        public override double Lidar(params object[] parametros)
        {
            var orcamento = parametros.FirstOrDefault() as Orcamento;
            if (orcamento.Valor > 500)
                return orcamento.Valor * 0.07;

            return Proximo is null ? 0 : Proximo.Lidar(parametros);
        }
    }
    internal class DescontoVendaCasada : Desconto
    {
        public override double Lidar(params object[] parametros)
        {
            var orcamento = parametros.FirstOrDefault() as Orcamento;
            if (orcamento.Itens.Exists(i => i.Nome.Equals("LAPIS", StringComparison.CurrentCultureIgnoreCase)) &&
                orcamento.Itens.Exists(i => i.Nome.Equals("CANETA", StringComparison.CurrentCultureIgnoreCase)))
                return orcamento.Valor * 0.05;

            return Proximo is null ? 0 : Proximo.Lidar(parametros);
        }
    }
    internal class CalculadorDesconto
    {
        public double CalcularDesconto(Orcamento orcamento)
        {
            var cadeiaDescontos = new CadeiaMultiplaDescontos(new DescontoMaisCincoItens(), new DescontoValorMaior500());

            return cadeiaDescontos.Lidar(orcamento);
        }
        //Faz uso do pattern Strategy
        public double CalcularDesconto(Orcamento orcamento, params Desconto[] descontosPossiveis)
        {
            var cadeiaDescontos = new CadeiaMultiplaDescontos(descontosPossiveis);

            return cadeiaDescontos.Lidar(orcamento);
        }
    }
    internal class CadeiaMultiplaDescontos : Desconto
    {
        private readonly List<Desconto> m_Handlers;

        internal CadeiaMultiplaDescontos(params Desconto[] handlers)
        {
            if (handlers == null || !handlers.Any())
            {
                throw new ArgumentNullException(nameof(handlers), "No handlers are set.");
            }

            m_Handlers = new List<Desconto>();
            m_Handlers.AddRange(handlers);
        }

        public override double Lidar(params object[] parametros)
        {
            if (m_Handlers.Count > 1)
            {
                for (var handlerIndex = 0; handlerIndex < m_Handlers.Count - 1; handlerIndex++)
                {
                    m_Handlers[handlerIndex].DefinirProximo(m_Handlers[handlerIndex + 1]);
                }
            }

            return m_Handlers[0].Lidar(parametros);
        }
    }
}
