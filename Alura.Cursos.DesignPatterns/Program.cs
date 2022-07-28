using Alura.Cursos.DesignPatterns.Adapter;
using Alura.Cursos.DesignPatterns.Prototype;
using System;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var cliente = new Cliente("Carlito", "Av. Jue, 42", DateTime.Now);
            var cliente2 = PrototypeHelper.CreateDeepCopy(cliente);
            cliente2.DataDeNascimento = cliente2.DataDeNascimento.AddMonths(5);
            Console.WriteLine(cliente.Nome);
            Console.WriteLine(cliente2.Nome);
            Console.WriteLine(cliente.DataDeNascimento);
            Console.WriteLine(cliente2.DataDeNascimento);

            Console.ReadKey();
        }
    }
}
