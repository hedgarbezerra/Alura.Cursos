using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility
{
    internal interface ICadeia<T>
    {
        T Lidar(params object[] parametros);
        void DefinirProximo(ICadeia<T> proximo);
    }
    internal abstract class CadeiaBase<T> : ICadeia<T>
    {
        protected ICadeia<T> Proximo { get; private set; }
        public void DefinirProximo(ICadeia<T> proximo) => this.Proximo = proximo;
        public abstract T Lidar(params object[] parametros);
    }

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
