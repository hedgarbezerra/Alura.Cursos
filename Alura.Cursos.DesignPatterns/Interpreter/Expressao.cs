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
    public abstract class ExpressaoBasica : IExpressao
    {
        protected IExpressao ExpressaoEsquerda { get; set; }
        protected IExpressao ExpressaoDireita { get; set; }
        protected ExpressaoBasica(IExpressao expressaoEsquerda, IExpressao expressaoDireita)
        {
            ExpressaoEsquerda = expressaoEsquerda;
            ExpressaoDireita = expressaoDireita;
        }

        public abstract double Avaliar();
    }
    public class ExpressaoNumerica : IExpressao
    {
        private readonly double _numero;

        public ExpressaoNumerica(double numero)
        {
            _numero = numero;
        }
        public double Avaliar() => _numero;
    }
    public class Soma : ExpressaoBasica
    {
        public Soma(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() + ExpressaoDireita.Avaliar();
        }
    }

    public class Subtracao : ExpressaoBasica
    {
        public Subtracao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() - ExpressaoDireita.Avaliar();
        }
    }
    public class Multiplicacao : ExpressaoBasica
    {
        public Multiplicacao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() * ExpressaoDireita.Avaliar();
        }
    }
    public class Divisao : ExpressaoBasica
    {
        public Divisao(IExpressao expressaoEsquerda, IExpressao expressaoDireita) : base(expressaoEsquerda, expressaoDireita)
        {
        }
        public override double Avaliar()
        {
            return ExpressaoEsquerda.Avaliar() / ExpressaoDireita.Avaliar();
        }
    }
}
