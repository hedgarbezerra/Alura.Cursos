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
            var contas = new List<Conta>()
            {
                new Conta("Fulano1", 300, string.Empty, 1, DateTime.Now.AddMonths(-3)),
                new Conta("Fulano2", 300, string.Empty, 2, DateTime.Now),
                new Conta("Fulano3", 900, string.Empty, 3, DateTime.Now),
                new Conta("Fulano4", 300, string.Empty, 4, DateTime.Now),
                new Conta("Fulano5", 100, string.Empty, 5, DateTime.Now)
            };

            var filtrar = new FiltragemContasFlagadas();
            var contasFlagadas = filtrar.ContasFlagadas(contas);
            foreach (var conta in contasFlagadas)
            {
                Console.WriteLine(conta.ToString());
            }   

            Console.ReadKey();
        }
    }
}
