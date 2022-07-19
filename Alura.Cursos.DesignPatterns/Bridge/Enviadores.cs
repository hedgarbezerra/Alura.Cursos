using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Bridge
{
    public interface IEnviador
    {
        public bool Enviar(IMensagem mensagem);
    }
    public class EnviadorSms: IEnviador
    {
        public bool Enviar(IMensagem mensagem)
        {
            Console.WriteLine(mensagem.Formatar());
            return true;
        }
    }
    public class EnviadorEmail : IEnviador
    {
        public bool Enviar(IMensagem mensagem)
        {
            Console.WriteLine(mensagem.Formatar());
            return true;
        }
    }
    public class EnviadorNotificacaoMobile : IEnviador
    {
        public bool Enviar(IMensagem mensagem)
        {
            Console.WriteLine(mensagem.Formatar());
            return true;
        }
    }
}
