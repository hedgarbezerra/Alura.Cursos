using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.State
{
    public interface IEstadoDeUmOrcamento
    {
        void AplicaDescontoExtra(Orcamento orcamento);
        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);
    }

    public abstract class EstadoDeUmOrcamento : IEstadoDeUmOrcamento
    {
        private bool _descontoAplicado;
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (!_descontoAplicado)
                orcamento.Valor -= ValorDesconto(orcamento);
            _descontoAplicado = true;
        }
        public abstract void Aprova(Orcamento orcamento);
        public abstract void Finaliza(Orcamento orcamento);
        public abstract void Reprova(Orcamento orcamento);
        protected abstract double ValorDesconto(Orcamento orcamento);
    }
    public class EmAprovacao : EstadoDeUmOrcamento
    {
        protected override double ValorDesconto(Orcamento orcamento) => orcamento.Valor * 0.05;

        public override void Aprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Aprovado();
        }

        public override void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }

        public override void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orcamento em aprovação não podem ir para finalizado diretamente");
        }
    }

    public class Aprovado : EstadoDeUmOrcamento
    {
        protected override double ValorDesconto(Orcamento orcamento) => orcamento.Valor * 0.02;
        public override void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está em estado de aprovação");
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento está em estado de aprovação e não pode ser reprovado");
        }

        public override void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }


    public class Reprovado : EstadoDeUmOrcamento
    {
        protected override double ValorDesconto(Orcamento orcamento)
        {
            throw new Exception("Orçamentos reprovados não recebem desconto extra!");
        }

        public override void Aprova(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }

        public override void Finaliza(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }
    }
    public class Finalizado : EstadoDeUmOrcamento
    {
        protected override double ValorDesconto(Orcamento orcamento)
        {
            throw new Exception("Orçamentos finalizados não recebem desconto extra!");
        }

        public override void Aprova(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }

        public override void Finaliza(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }
    }
}
