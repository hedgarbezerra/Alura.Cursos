using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.DependencyInversion.Bad
{
    internal class EnviadorNotificacao
    {
        public void Notificar(string mensagem, string destinario, string tipoNotificacao)
        {
            if (tipoNotificacao == "SMS")
                new NotificadorSMS().EnviaSMS(mensagem, destinario);
            else
            {
                new NotificadorEmail().EnviaEmail(mensagem, destinario);
            }
            //Caso existam mais tipos, adicionar mais condições
        }
    }
}
