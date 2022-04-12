using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility
{
    public abstract class CadeiaGenerica<TIn, TOut> 
        where TIn : class 
    {
        public TIn Proximo { get; private set; }

        public void DefinirProximo(TIn proximo)
        {
            Proximo = proximo;
        }
        public abstract TOut Lidar(params object[] parametros);
    }
}
