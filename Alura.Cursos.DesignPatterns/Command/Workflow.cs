using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Command
{
    public class Workflow
    {
        private IList<ICommand> comandos = new List<ICommand>();
        public void Adiciona(ICommand comando)
        {
            comandos.Add(comando);
        }

        public void Processa()
        {
            foreach (ICommand comando in comandos)
            {
                comando.Execute();
            }
        }
    }
}
