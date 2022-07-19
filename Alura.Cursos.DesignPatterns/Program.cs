using Alura.Cursos.DesignPatterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMensagem msg = new Sms()
            {
                Formatador = new FormatadorSms(),
                Mensagem = "Mensagem",
                Remetente = "Carlos",
                Destinario = "11993912732"
            };

            var enviadorSms = new EnviadorSms();
            var enviadorEmail = new EnviadorEmail();
            enviadorSms.Enviar(msg);
            enviadorEmail.Enviar(msg);

            Console.ReadKey();
        }
    }
}
