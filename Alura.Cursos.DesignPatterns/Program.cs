using Alura.Cursos.DesignPatterns.ChainOfResponsibility;
using System;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario() { Nome = "Hedgar", Email = "Hedgar123", Senha = "aaadsda", DataNascimento =  new DateTime(1997, 01, 01) };
            var validador = new ValidadorUsuario();
            
            Console.WriteLine(validador.Validar(usuario));

            Console.ReadLine();
        }
    }
}
