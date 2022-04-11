using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.InterfaceSegregation.Good
{
    internal class GravaTocadorTop : IGravadorMusica, ITocadorMusica
    {
        public void GravaMusica()
        {//Grava Musica
        }

        public void TocaMusica()
        {
            //Toca Musica
        }
    }
}
