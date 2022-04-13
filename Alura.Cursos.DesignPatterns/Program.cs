using Alura.Cursos.DesignPatterns.ChainOfResponsibility;
using Alura.Cursos.DesignPatterns.ChainOfResponsibility.Descontos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var descontoItens = new DescontoMaisCincoItens();
            var descontoValor = new DescontoValorMaior500();
            var descontoVendaCasada = new DescontoVendaCasada();

            var calculadorDesconto = new CalculadorDesconto();

            var orcamento = new Orcamento()
            {
                Itens = new List<Item>()
                {
                    new Item("PC", 100),
                    new Item("lapis", 10),
                    new Item("caneta", 10),
                    new Item("Xbox", 100)
                }
            };

            var desconto1 = calculadorDesconto.CalcularDesconto(orcamento);
            var desconto2 = calculadorDesconto.CalcularDesconto(orcamento, descontoItens);
            var desconto3 = calculadorDesconto.CalcularDesconto(orcamento, descontoItens, descontoValor, descontoVendaCasada);

            Console.WriteLine(desconto1);
            Console.WriteLine(desconto2);
            Console.WriteLine(desconto3);
            Console.ReadLine();
        }
    }

}
