using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.DependencyInversion.Good
{
    internal class NotificadorEmail : INotificador
    {
        public void Notificar(string mensagem, string destinario)
        {
            //Faz Algo
        }
    }
}
