using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.FlyWeight
{
    public class OutrasNotasMusicais
    {
        public static readonly INota Do = new Do();
    }

    public class NotasMusicais
    {
        private static IDictionary<string, INota> _notas = new Dictionary<string, INota>()
        {
        { "do", new Do() } ,
        { "re", new Re() } ,
        { "mi", new Mi() },
        { "fa", new Fa() },
        { "sol", new Sol() },
        { "la", new La() },
        { "si", new Si() }
        };


        public INota Pega(string nome)
        {
            if(_notas.TryGetValue(nome, out INota result))
                return result;
            throw new ArgumentException($"A nota {nome} não foi encontrada.");
        }
    }
    public interface INota
    {
        int Frequencia { get; }
    }

    internal class Si : INota
    {
        public int Frequencia => 1;
    }

    internal class La : INota
    {
        public int Frequencia => 2;
    }

    internal class Sol : INota
    {
        public int Frequencia => 3;
    }

    internal class Fa : INota
    {
        public int Frequencia => 4;
    }

    internal class Mi : INota
    {
        public int Frequencia => 5;
    }

    internal class Re : INota
    {
        public int Frequencia => 6;
    }

    public class Do : INota
    {
        public int Frequencia => 7;
    }
}
