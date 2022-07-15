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
    }
    public abstract class ExpressaoComposta : IExpressao
    {
        protected IExpressao ExpressaoEsquerda { get; private set; }
        protected IExpressao ExpressaoDireita { get; private set; }
        protected ExpressaoComposta(IExpressao expressaoEsquerda, IExpressao expressaoDireita)
        {
            ExpressaoEsquerda = expressaoEsquerda;
            ExpressaoDireita = expressaoDireita;
        }

        public abstract double Avaliar();
    }
    public abstract class ExpressaoBasica : IExpressao
    {
        protected double Numero { get; private set; }
        protected ExpressaoBasica(double numero)
        {
            Numero = numero;
        }

        public abstract double Avaliar();
    }
    public class Soma : ExpressaoComposta
    {
        public Soma(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() + ExpressaoDireita.Avaliar();
        }
    }

    public class Subtracao : ExpressaoComposta
    {
        public Subtracao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() - ExpressaoDireita.Avaliar();
        }
    }
    public class Multiplicacao : ExpressaoComposta
    {
        public Multiplicacao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() * ExpressaoDireita.Avaliar();
        }
    }
    public class Divisao : ExpressaoComposta
    {
        public Divisao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() / ExpressaoDireita.Avaliar();
        }
    }
    public class ExpressaoNumerica : ExpressaoBasica
    {
        public ExpressaoNumerica(double numero) : base(numero)
        {
        }
        public override double Avaliar() => Numero;
    }
    public class RaizQuadrada : ExpressaoComposta
    {
        public RaizQuadrada(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return Math.Sqrt(ExpressaoEsquerda.Avaliar() / ExpressaoDireita.Avaliar());
        }
    }
}
