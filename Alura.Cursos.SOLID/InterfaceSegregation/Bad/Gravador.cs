using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.InterfaceSegregation.Bad
{
    internal class Gravador : IGerenciadorMusica
    {
        public void GravaMusica()
        {
            //Logica de gravar música
        }

        //Não toca música, é um gravador
        public void TocaMusica()
        {
            throw new NotImplementedException();
        }
    }
}
