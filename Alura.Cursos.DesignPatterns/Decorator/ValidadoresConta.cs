using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Decorator
{
    abstract class ValidadorConta
    {
        public ValidadorConta ProximoValidador { get; set; }
        protected abstract string Mensagem { get; }
        protected ValidadorConta(ValidadorConta proximoValidador = null)
        {
            ProximoValidador = proximoValidador;
        }

        public IEnumerable<string> Validar(Conta conta)
        {
            var mensagens = new List<string>();

            if(!ValidarConta(conta))
                mensagens.Add(Mensagem);

            return ProximoValidador is null ? mensagens : mensagens.Concat(ProximoValidador.Validar(conta));
        }
        protected abstract bool ValidarConta(Conta conta);   
    }
    class ValidadorTitularConta : ValidadorConta
    {
        public ValidadorTitularConta(ValidadorConta proximoValidador = null) : base(proximoValidador) { }
        protected override string Mensagem => "Titular inválido ou vazio.";

        protected override bool ValidarConta(Conta conta) => !string.IsNullOrEmpty(conta.Titular);

    }
    class ValidadorAgenciaConta : ValidadorConta
    {
        public ValidadorAgenciaConta(ValidadorConta proximoValidador = null) : base(proximoValidador) { }
        protected override string Mensagem => "Agencia da conta é inválida.";

        protected override bool ValidarConta(Conta conta) => !string.IsNullOrEmpty(conta.Agencia);
    }
    class ValidadorDataCriacaoConta : ValidadorConta
    {
        public ValidadorDataCriacaoConta(ValidadorConta proximoValidador = null) : base(proximoValidador) { }
        protected override string Mensagem => "A data de criação da conta é inválida.";

        protected override bool ValidarConta(Conta conta) => DateTime.Today.Date > conta.DataCriacao.Date;
    }
    class ValidadorNumeroConta : ValidadorConta
    {
        public ValidadorNumeroConta(ValidadorConta proximoValidador = null) : base(proximoValidador) { }
        protected override string Mensagem => $"O número da conta da conta é inválida.";

        protected override bool ValidarConta(Conta conta) => conta.Numero > 0;
    }
    class ValidadoresConta
    {
        private readonly ValidadorConta _validadorTitular;
        private readonly ValidadorConta _validadorAgencia;
        private readonly ValidadorConta _validadorData;
        private readonly ValidadorConta _validadorNumero;
        public ValidadoresConta()
        {
            _validadorNumero = new ValidadorNumeroConta();
            _validadorData = new ValidadorDataCriacaoConta(_validadorNumero);
            _validadorAgencia = new ValidadorAgenciaConta(_validadorData);
            _validadorTitular = new ValidadorTitularConta(_validadorAgencia);
        }

        public IEnumerable<string> Validar(Conta conta) => _validadorTitular.Validar(conta);
    }

}
