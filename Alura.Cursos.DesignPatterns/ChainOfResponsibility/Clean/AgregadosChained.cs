using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility.Clean
{
    internal class CadeiaMultiplaValidadores : CadeiaBase<bool>
    {
        private readonly List<ICadeia<bool>> m_Handlers;

        internal CadeiaMultiplaValidadores(params ICadeia<bool>[] handlers)
        {
            if (handlers == null || !handlers.Any())
            {
                throw new ArgumentNullException(nameof(handlers), "No handlers are set.");
            }

            m_Handlers = new List<ICadeia<bool>>();
            m_Handlers.AddRange(handlers);
        }

        public override bool Lidar(params object[] parametros)
        {
            if (m_Handlers.Count > 1)
            {
                for (var handlerIndex = 0; handlerIndex < m_Handlers.Count - 1; handlerIndex++)
                {
                    m_Handlers[handlerIndex].DefinirProximo(m_Handlers[handlerIndex + 1]);
                }
            }

            return m_Handlers[0].Lidar(parametros);
        }
    }
}
