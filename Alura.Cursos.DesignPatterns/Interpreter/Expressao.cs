using Alura.Cursos.DesignPatterns.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Interpreter
{
    //O pattern Interpreter visa ter uma "raiz" com expressões a serem resolvidas
    public interface IExpressao
    {
        double Avaliar();
        string Converter();
    }
    public abstract class ExpressaoComposta : IExpressao
    {
        protected readonly IFormatadorVisitor _formatador;
        public IExpressao ExpressaoEsquerda { get; private set; }
        public IExpressao ExpressaoDireita { get; private set; }
        protected ExpressaoComposta(IExpressao expressaoEsquerda, IExpressao expressaoDireita, IFormatadorVisitor formatador)
        {
            ExpressaoEsquerda = expressaoEsquerda;
            ExpressaoDireita = expressaoDireita;
            _formatador = formatador;
        }

        public abstract double Avaliar();

        public string Converter() => _formatador?.Formatar(this);
    }
    public abstract class ExpressaoBasica : IExpressao
    {
        protected readonly IFormatadorVisitor _formatador;
        public double Numero { get; private set; }
        protected ExpressaoBasica(double numero, IFormatadorVisitor formatador)
        {
            Numero = numero;
            _formatador = formatador;
        }

        public abstract double Avaliar();
        public string Converter() => _formatador?.Formatar(this);    
    }
    public class Soma : ExpressaoComposta
    {
        public Soma(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorSomaVisitor)))
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() + ExpressaoDireita.Avaliar();
        }
    }

    public class Subtracao : ExpressaoComposta
    {
        public Subtracao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorSubtracaoVisitor)))
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() - ExpressaoDireita.Avaliar();
        }
    }
    public class Multiplicacao : ExpressaoComposta
    {
        public Multiplicacao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorMultiplicacaoVisitor)))
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() * ExpressaoDireita.Avaliar();
        }
    }
    public class Divisao : ExpressaoComposta
    {
        public Divisao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorDivisaoVisitor)))
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() / ExpressaoDireita.Avaliar();
        }
    }
    public class ExpressaoNumerica : ExpressaoBasica
    {
        public ExpressaoNumerica(double numero) : base(numero, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorNumericaVisitor)))
        {
        }
        public override double Avaliar() => Numero;
    }
    public class RaizQuadrada : ExpressaoComposta
    {
        public RaizQuadrada(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita, FormatadoresFlyWeight.PegarFormatador(typeof(FormatadorRaizQuadradaVisitor)))
        {
        }
        public override double Avaliar()
        {
            return Math.Sqrt(ExpressaoEsquerda.Avaliar() / ExpressaoDireita.Avaliar());
        }
    }
}
