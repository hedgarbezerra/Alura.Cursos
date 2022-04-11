using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.OpenClosed.Good
{
    internal class NotificadorSMS : INotificador
    {
        public void Notificar(string destinario, string mensagem)
        {
            //Envia SMS
        }
    }
}
