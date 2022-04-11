using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.OpenClosed.Good
{
    internal class NotificadorMultiplo : INotificador
    {
        //Utilizando o pattern Decorator, fazendo extensão da funcionalidade que já existe, sem herdas das classes
        private readonly INotificador _notificadorEmail;
        private readonly INotificador _notificadorSMS;

        public NotificadorMultiplo(NotificadorEmail notificadorEmail, NotificadorSMS notificadorSMS)
        {
            _notificadorEmail = notificadorEmail;
            _notificadorSMS = notificadorSMS;
        }

        public void Notificar(string destinario, string mensagem)
        {
            _notificadorEmail.Notificar(destinario, mensagem);
            _notificadorSMS.Notificar(destinario, mensagem);
        }
    }
}
