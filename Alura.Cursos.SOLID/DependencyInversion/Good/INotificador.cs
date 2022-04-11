using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.DependencyInversion.Good
{
    internal interface INotificador
    {
        void Notificar(string mensagem, string destinario);
    }
}
