using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.DependencyInversion.Good
{
    internal class EnviadorNotificacao
    {
        private readonly INotificador _notificador;

        //Inverto a dependência, não mais precisando criar uma instância de acordo com o tipo, agora o notificador apenas é chamado,
        //sem nos preocuparmos com o que acontece por trás da abstração
        public EnviadorNotificacao(INotificador notificador)
        {
            _notificador = notificador;
        }

        public void EnviaNotificacao(string mensagem, string destinario)
        {
            _notificador.Notificar(mensagem, destinario);
        }
    }
}
