using Alura.Cursos.DesignPatterns.Bridge;
using Alura.Cursos.DesignPatterns.Command;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        /// <summary>
        /// O pattern Command visa ter um comando único para ser utilizado no código todo, por exemplo: Capturar dados de uma NF.
        /// E esse comand odeve ser executado seguindo um fluxo de trabalho
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Pedido pedido1 = new Pedido("Mauricio", 150.0);
            Pedido pedido2 = new Pedido("Marcelo", 250.0);

            Workflow fila = new Workflow();

            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));
            fila.Adiciona(new FinalizaPedido(pedido1));

            fila.Processa();
        }
    }
}
