using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Memento
{
    public class Contrato
    {
        public DateTime Data { get; private set; }
        public string Cliente { get; private set; }
        public TipoContrato Tipo { get; private set; }

        public Contrato(DateTime data, String cliente, TipoContrato tipo)
        {
            this.Data = data;
            this.Cliente = cliente;
            this.Tipo = tipo;
        }

        public void Avanca()
        {
            if (this.Tipo == TipoContrato.Novo) this.Tipo = TipoContrato.EmAndamento;
            else if (this.Tipo == TipoContrato.EmAndamento) this.Tipo = TipoContrato.Acertado;
            else if (this.Tipo == TipoContrato.Acertado) this.Tipo = TipoContrato.Concluido;
        }
        public Estado SalvaEstado()
        {
            return new Estado(new Contrato(this.Data, this.Cliente, this.Tipo));
        }
    }
    public enum TipoContrato
    {
        Novo,
        EmAndamento,
        Acertado,
        Concluido
    }
    public class Estado
    {
        public Contrato Contrato { get; private set; }

        public Estado(Contrato contrato)
        {
            this.Contrato = contrato;
        }
    }

    public class Historico
    {
        private IList<Estado> Estados = new List<Estado>();

        public Estado Pega(int index)
        {
            return Estados.ElementAtOrDefault(index);
        }

        public void Adiciona(Estado estado)
        {
            Estados.Add(estado);
        }
    }

    class TesteMemento
    {
        public void Teste()
        {
            Historico historico = new Historico();

            Contrato contrato = new Contrato(DateTime.Now, "Hedgar", TipoContrato.Novo);
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());
        }
    }
}
