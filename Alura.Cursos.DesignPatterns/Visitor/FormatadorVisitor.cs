using Alura.Cursos.DesignPatterns.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Visitor
{
    /// <summary>
    /// O pattern visitor visa percorrer a árvore/expressão, como um interpreter e aplicar alguma lógica em cima a arvore
    /// </summary>
    public interface IFormatadorVisitor
    {
        string Formatar(IExpressao expressao);
    }
    public abstract class FormatadorVisitor : IFormatadorVisitor
    {
        protected StringBuilder _stringBuilder;

        protected FormatadorVisitor(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        protected FormatadorVisitor()
        {
            _stringBuilder = new StringBuilder();
        }

        public abstract string Formatar(IExpressao expressao);
    }

    public abstract class FormatadorVisitorComposto<T> : FormatadorVisitor
        where T : ExpressaoComposta
    {
        public override string Formatar(IExpressao expressao)
        {
            var exp = (T)expressao;
            _stringBuilder.Append("(");
            _stringBuilder.Append(exp.ExpressaoEsquerda.Converter());
            _stringBuilder.Append(Sinal());
            _stringBuilder.Append(exp.ExpressaoDireita.Converter());
            _stringBuilder.Append(")");

            return _stringBuilder.ToString();
        }
        protected abstract string Sinal();
    }
    public class FormatadorSomaVisitor : FormatadorVisitorComposto<Soma>
    {
        protected override string Sinal() => " + ";
    }
    public class FormatadorSubtracaoVisitor : FormatadorVisitorComposto<Subtracao>
    {
        protected override string Sinal() => " - ";

    }
    public class FormatadorMultiplicacaoVisitor : FormatadorVisitorComposto<Multiplicacao>
    {
        protected override string Sinal() => " * ";

    }
    public class FormatadorDivisaoVisitor : FormatadorVisitorComposto<Divisao>
    {
        protected override string Sinal() => " / ";

    }
    public class FormatadorRaizQuadradaVisitor : FormatadorVisitorComposto<RaizQuadrada>
    {
        protected override string Sinal() => " √ ";
    }
    public class FormatadorNumericaVisitor : FormatadorVisitor
    {
        public override string Formatar(IExpressao expressao)
        {
            var exp = (ExpressaoNumerica)expressao;

            return exp.Numero.ToString();
        }
    }
}
