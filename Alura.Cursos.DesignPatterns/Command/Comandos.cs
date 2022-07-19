using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Command
{
    public interface ICommand
    {
        void Execute();
    }
    public class FinalizaPedido : ICommand
    {
        private Pedido pedido;

        public FinalizaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }

        public void Execute()
        {
            pedido.Finaliza();
        }
    }

    public class PagaPedido : ICommand
    {
        private Pedido pedido;

        public PagaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }

        public void Execute()
        {
            pedido.Paga();
        }
    }
}
