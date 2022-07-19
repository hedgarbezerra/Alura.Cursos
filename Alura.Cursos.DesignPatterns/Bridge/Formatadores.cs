using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Bridge
{
    public interface IFormatadorMensagem
    {
        string Formatar(IMensagem msg);
    }
    public class FormatadorEmail : IFormatadorMensagem
    {
        public string Formatar(IMensagem msg) => $"Email para {msg.Destinario}";
    }
    public class FormatadorSms : IFormatadorMensagem
    {
        public string Formatar(IMensagem msg) => $"SMS para {msg.Destinario}";
    }
    public class FormatadorNotificadorMobile : IFormatadorMensagem
    {
        public string Formatar(IMensagem msg) => $"Notificação para {msg.Destinario}";
    }
}
