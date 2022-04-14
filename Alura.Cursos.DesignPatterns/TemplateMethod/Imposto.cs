using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.TemplateMethod
{
    class Item
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
    class Orcamento
    {
        public double Valor { get => Itens.Sum(i => i.Valor); }
        public List<Item> Itens { get; set; }
    }
    interface IImposto
    {
        double Calcular(Orcamento orcamento);
    }
    class ImpostoISS : IImposto
    {
        public double Calcular(Orcamento orcamento) => orcamento.Valor * 0.06;
    }
    class ImpostoICMS : IImposto
    {
        public double Calcular(Orcamento orcamento) => (orcamento.Valor * 0.05) + 50;
    }
    abstract class TemplateDeImpostoCondicional : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento);
            return MinimaTaxacao(orcamento);
        }

        protected abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);
    }
    class IKCV : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && orcamento.Itens.Any(i => i.Valor > 100);
        }
        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.10;
        }
        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
    class ICPP : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }
        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }
        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    class IHIT : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento) => orcamento.Itens.GroupBy(x => x.Nome).Any(g => g.Count() > 1);

        protected override double MaximaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.13 + 100;

        protected override double MinimaTaxacao(Orcamento orcamento) => orcamento.Itens.Count * 0.01;
    }

    class CalculadorImpostos
    {
        public double Calcular(Orcamento orcamento, IImposto imposto)
        {
            return imposto.Calcular(orcamento);
        }
    }
}
