using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Interpreter
{
    public class Teste
    {
        public static void Maiasan(string[] args)
        {
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", roman, context.Output);

            //Padrão Interpreter para calculo matemático

            IExpressao expressao = new Subtracao(new ExpressaoNumerica(2), new Multiplicacao(new ExpressaoNumerica(5), new ExpressaoNumerica(2)));
            var resultado = expressao.Avaliar();
            Console.WriteLine(resultado);

            //Padrão Interpreter default do .NET

            Expression<Func<double, double, double>> expression = (num1, num2) => num1 + num2;
            Console.WriteLine(expression.Compile().Invoke(1, 65));

            Console.ReadKey();
        }
    }
}
