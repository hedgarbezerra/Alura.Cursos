using Alura.Cursos.DesignPatterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculador = new CalculadorImpostos();
            var impostos = new ImpostoIKCV(new ImpostoICPP(new ImpostoHigh()));
            var orcamento = new Orcamento()
            {
                Itens = new List<Item>()
                {
                    new Item("PC", 500),
                    new Item("PC", 600),
                    new Item("lapis", 10),
                    new Item("caneta", 10),
                    new Item("Xbox", 1000)
                }
            };


            Console.WriteLine(calculador.Calcular(orcamento, impostos));
            Console.WriteLine(calculador.Calcular(orcamento, new ImpostoIKCV()));
            Console.WriteLine(calculador.Calcular(orcamento, new ImpostoICPP()));
            Console.WriteLine(calculador.Calcular(orcamento, new ImpostoHigh()));
            Console.ReadLine();
        }
    }
}
