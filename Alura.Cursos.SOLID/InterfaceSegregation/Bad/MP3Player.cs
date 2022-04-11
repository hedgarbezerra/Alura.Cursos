using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.InterfaceSegregation.Bad
{
    internal class MP3Player : IGerenciadorMusica
    {
        //Não grava música, só toca...😉
        public void GravaMusica()
        {
            throw new NotImplementedException();
        }

        public void TocaMusica()
        {
            //Toca música
        }
    }
}
