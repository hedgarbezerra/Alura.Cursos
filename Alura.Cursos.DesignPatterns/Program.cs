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
            var conta = new Conta("", 300, string.Empty, 1, DateTime.Now.AddMonths(3));
            var validador = new ValidadoresConta();

            var result = validador.Validar(conta);
            Console.WriteLine(string.Join("\n ", result));
            Console.ReadKey();
        }
    }
}
