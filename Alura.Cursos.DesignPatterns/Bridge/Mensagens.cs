using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Bridge
{
    public interface IMensagem
    {
        IFormatadorMensagem Formatador { get; set; }
        string Remetente { get; set; }
        string Destinario { get; set; }
        string Mensagem { get; set; }
        string Formatar();
    }
    public abstract class MensagemBase : IMensagem
    {
        public IFormatadorMensagem Formatador { get; set; }
        public string Remetente { get; set; }
        public string Destinario { get; set; }
        public string Mensagem { get; set; }

        public abstract string Formatar();
    }
    public class Sms : MensagemBase
    {
        public IFormatadorMensagem Formatador { get ; set ; }

        public override string Formatar() => Formatador.Formatar(this);
    }
    public class Email : MensagemBase
    {
        public IFormatadorMensagem Formatador { get; set; }

        public override string Formatar() => Formatador.Formatar(this);
    }
    public class NotificacaoMobile : MensagemBase
    {
        public IFormatadorMensagem Formatador { get; set; }

        public override string Formatar() => Formatador.Formatar(this);

    }
}
