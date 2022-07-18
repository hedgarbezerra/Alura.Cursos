using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Visitor
{
    public static class FormatadoresFlyWeight
    {
        private static Dictionary<Type, IFormatadorVisitor> visitors = new Dictionary<Type, IFormatadorVisitor>()
        {
            { typeof(FormatadorSomaVisitor), new FormatadorSomaVisitor() },
            { typeof(FormatadorSubtracaoVisitor), new FormatadorSubtracaoVisitor() },
            { typeof(FormatadorMultiplicacaoVisitor), new FormatadorMultiplicacaoVisitor() },
            { typeof(FormatadorDivisaoVisitor), new FormatadorDivisaoVisitor() },
            { typeof(FormatadorRaizQuadradaVisitor), new FormatadorRaizQuadradaVisitor() },
            { typeof(FormatadorNumericaVisitor), new FormatadorNumericaVisitor() },
        };

        public static IFormatadorVisitor PegarFormatador(Type tipoFormatador)
        {
            if(visitors.TryGetValue(tipoFormatador, out var visitor))
                return visitor;
            return null;
        }
    }
}
