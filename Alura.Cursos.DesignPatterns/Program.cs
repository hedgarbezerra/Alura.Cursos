using Alura.Cursos.DesignPatterns.Builder;
using Alura.Cursos.DesignPatterns.Interpreter;
using Alura.Cursos.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IExpressao expressao = new Subtracao(new ExpressaoNumerica(2), new Multiplicacao(new ExpressaoNumerica(5), new ExpressaoNumerica(2)));
            var resultado = expressao.Avaliar();
            Console.WriteLine(resultado);

            //Padrão Interpreter default do .NET

            Expression<Func<double, double, double>> expression = (num1, num2) => num1 + num2;
            Console.WriteLine(expression.Compile().Invoke(1, 65));

            Console.WriteLine(expressao.Converter());

            Console.ReadKey();
        }
    }
}
