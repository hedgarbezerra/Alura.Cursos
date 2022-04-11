using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.OpenClosed.Bad
{
    internal class Notificador
    {
        public void EnviaEmail(string destinario, string mensagem)
        {
        }
        //Após um periodo o cliente decide que também quer mandar SMS

        public void EnviaSMS(string destinario, string mensagem){ }

        //E após um período decide que deseja enviar ambos juntos

        public void EnviaSMSEMAIL(string destinario, string mensagem) { }

        //Uma clara violação do princípio OCP que tenta enviar a alteração de funcionalidades que já estavam prontas e funcionais
        //Além de também violar o SRP pois a classe faz três coisas
    }
}
