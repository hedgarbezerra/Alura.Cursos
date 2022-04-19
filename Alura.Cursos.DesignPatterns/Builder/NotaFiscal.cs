using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder
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

    class Cliente
    {
        public Cliente() { }
        public Cliente(string nome, string documento, string uF, bool isConsumidorFinal)
        {
            Nome = nome;
            Documento = documento;
            UF = uF;
            IsConsumidorFinal = isConsumidorFinal;
        }

        public string Nome { get; set; }
        public string Documento { get; set; }
        public string UF { get; set; }
        public bool IsConsumidorFinal { get; set; }

    }

    class NotaFiscal
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataDeEmissao { get; set; }
        public double Impostos { get; set; }
        public IList<Item> Itens { get; set; }
        public string Observacoes { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorBruto => Itens.Sum(i => i.Valor);

        public NotaFiscal() { Itens = new List<Item>(); }
        public NotaFiscal(string razaoSocial, string cnpj, double impostos, string observacoes, DateTime dataDeEmissao, IList<Item> itens)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.DataDeEmissao = dataDeEmissao;
            this.Impostos = impostos;
            this.Itens = itens;
            this.Observacoes = observacoes;
        }
    }
}
