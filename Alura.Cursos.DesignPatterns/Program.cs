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
            var banco = new Banco("Santana", "Av. tururu, 38", "+55 032 198723823", "contato@Santana.com.br");
            banco.Contas = new List<Conta>()
            {
                new Conta("Carlos F Rodrigues", 92830, "989912", 9237390),
                new Conta("José F Rodrigues", 2830, "989912", 92378192),
                new Conta("Maria F Mondin", 930, "989912", 92340),
            };

            var geradorRelatorio = new RelatorioComplexo();
            var geradorRelatorio1 = new RelatorioSimples();

            geradorRelatorio.Imprimir(banco);
            geradorRelatorio1.Imprimir(banco);
            Console.ReadLine();
        }
    }
}
