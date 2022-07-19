using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Command
{
    public class Pedido
    {
        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public Status Status { get; private set; }
        public DateTime DataFinalizacao { get; private set; }

        public Pedido(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            Status = Status.Novo;
        }

        public void Paga()
        {
            Status = Status.Pago;
        }

        public void Finaliza()
        {
            DataFinalizacao = DateTime.Now;
            Status = Status.Entregue;
        }
    }

    public enum Status
    {
        Novo,
        Processado,
        Pago,
        ItemSeparado,
        Entregue
    }
}
