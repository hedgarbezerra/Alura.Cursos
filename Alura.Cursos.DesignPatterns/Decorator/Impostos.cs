using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Decorator
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
    abstract class Imposto : IImposto
    {
        protected IImposto Proximo { get; set; }
        public Imposto(IImposto proximoImposto) { Proximo = proximoImposto; }

        public virtual double Calcular(Orcamento orcamento)
        {
            return ImpostoCalculado(orcamento) + (Proximo is not null ? Proximo.Calcular(orcamento) : 0);
        }
        public abstract double ImpostoCalculado(Orcamento orcamento);
    }
    class ImpostoISS : Imposto
    {
        public ImpostoISS(IImposto imposto = null)
            : base(imposto) { }
        public override double ImpostoCalculado(Orcamento orcamento) => orcamento.Valor * 0.06;
    }
    class ImpostoHigh : Imposto
    {
        public ImpostoHigh(IImposto imposto = null)
            : base(imposto) { }
        public override double ImpostoCalculado(Orcamento orcamento) => orcamento.Valor * 0.2;
    }
    class ImpostoICMS : Imposto
    {
        public ImpostoICMS(IImposto imposto = null)
               : base(imposto) { }
        public override double ImpostoCalculado(Orcamento orcamento) => (orcamento.Valor * 0.05) + 50;
    }
    abstract class TemplateDeImpostoCondicional : Imposto
    {
        public TemplateDeImpostoCondicional(IImposto imposto)
               : base(imposto) { }
        public override double ImpostoCalculado(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento);
            return MinimaTaxacao(orcamento);
        }

        protected abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);
    }
    class ImpostoIKCV : TemplateDeImpostoCondicional
    {
        public ImpostoIKCV(IImposto imposto = null)
               : base(imposto) { }
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
    class ImpostoICPP : TemplateDeImpostoCondicional
    {
        public ImpostoICPP(IImposto imposto = null)
               : base(imposto) { }
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

    class ImpostoIHIT : TemplateDeImpostoCondicional
    {
        public ImpostoIHIT(IImposto imposto = null)
                 : base(imposto) { }
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
