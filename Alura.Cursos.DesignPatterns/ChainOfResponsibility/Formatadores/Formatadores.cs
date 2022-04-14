using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility.Formatadores
{
    enum Formato
    {
        XML,
        CSV,
        PORCENTO
    }

    class Requisicao
    {
        public Formato Formato { get; private set; }

        public Requisicao(Formato formato)
        {
            this.Formato = formato;
        }
    }
    class Conta
    {
        public Conta()
        {
        }

        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
        }

        public string Titular { get; set; }
        public double Saldo { get; set; }
    }
    interface ICadeiaResposta
    {
        string Lidar(Requisicao req, Conta conta);
        void DefinirProximo(ICadeiaResposta proximo);
    }
    abstract class CadeiaRespostaBase : ICadeiaResposta
    {
        protected ICadeiaResposta Proximo { get; private set; }
        public void DefinirProximo(ICadeiaResposta proximo) => this.Proximo = proximo;
        public virtual string Lidar(Requisicao req, Conta conta)
        {
            if (TipoDesejado(req)) return ContaFormatada(conta);
            else
                return Proximo is null ? string.Empty : Proximo.Lidar(req, conta);
        }
        public abstract string ContaFormatada(Conta conta);
        public abstract bool TipoDesejado(Requisicao req);
    }

    class FormatadorRequisicaoEncadeado
    {
        private readonly List<ICadeiaResposta> _formatadores;
        public FormatadorRequisicaoEncadeado(params ICadeiaResposta[] formatadores)
        {
            _formatadores = formatadores?.ToList() ?? throw new ArgumentNullException(nameof(formatadores));
        }
        public string Formatar(Requisicao req, Conta conta)
        {
            if (_formatadores.Count > 1)
            {
                for (var handlerIndex = 0; handlerIndex < _formatadores.Count - 1; handlerIndex++)
                {
                    _formatadores[handlerIndex].DefinirProximo(_formatadores[handlerIndex + 1]);
                }
            }
            return _formatadores[0].Lidar(req, conta);
        }
    }

    class FormatadorRequisicaoXML : CadeiaRespostaBase
    {
        public override string ContaFormatada(Conta conta)
        {
            var raiz = new XElement("conta");
            conta.GetType()
                .GetProperties()
                .ToList()
                .ForEach(p => raiz.SetAttributeValue(p.Name.ToLower(), p.GetValue(conta).ToString()));

            return raiz.ToString();
        }

        public override bool TipoDesejado(Requisicao req) => req.Formato == Formato.XML;
    }
    class FormatadorRequisicaoCSV : CadeiaRespostaBase
    {
        public override string ContaFormatada(Conta conta) => string.Join(",", conta.GetType()
            .GetProperties()
            .Select(p => p.GetValue(conta).ToString()));

        public override bool TipoDesejado(Requisicao req) => req.Formato == Formato.CSV;
    }
    class FormatadorRequisicaoPorcentagem : CadeiaRespostaBase
    {
        public override string ContaFormatada(Conta conta) => String.Join("%", conta.GetType()
            .GetProperties()
            .Select(p => p.GetValue(conta).ToString()));

        public override bool TipoDesejado(Requisicao req) => req.Formato == Formato.PORCENTO;
    }
}
