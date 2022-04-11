using System;

namespace Alura.Cursos.SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IFuncionario
    {
        public double CalculaSalario();
    }
    public abstract class Funcionario
    {
        protected double _salario;
        public virtual double CalculaSalario()
        {
            return _salario;
        }
    } 

    public class Estagiario : Funcionario
    {
        public override double CalculaSalario()
        {
            return _salario * 0.2;
        }
    }
    public class Gerente : Funcionario
    {
        public override double CalculaSalario()
        {
            return _salario * 0.6;
        }
    }
}
