using Alura.Cursos.DesignPatterns.TemplateMethod;
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
            var icpp = new ICPP();
            var ikcv = new IKCV();
            var hit = new IHIT();

            var calculador = new CalculadorImpostos();

            Console.WriteLine(calculador.Calcular(orcamento, icpp));
            Console.WriteLine(calculador.Calcular(orcamento, ikcv));
            Console.WriteLine(calculador.Calcular(orcamento, hit));
            Console.ReadLine();
        }
    }
}
