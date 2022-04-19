using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder
{
    interface INotaFiscalBuilder : INotaFiscalItensBuilder
    {
        void Reset();
        NotaFiscal Build();
    }

    interface INotaFiscalRazaoSocialBuilder : INotaFiscalBuilder
    {
        INotaFiscalCNPJBuilder ComRazaoSocial(string razaoSocial);
    }
    interface INotaFiscalCNPJBuilder : INotaFiscalBuilder
    {
        INotaFiscalEmissaoBuilder ComCNPJ(string cnpj);
    }

    interface INotaFiscalEmissaoBuilder : INotaFiscalBuilder
    {
        INotaFiscalImpostosBuilder ComDataEmissao(DateTime? dataEmissao = null);
    }

    interface INotaFiscalImpostosBuilder : INotaFiscalBuilder
    {
        INotaFiscalObservacoesBuilder ComTotalImpostos(double impostos);
    }

    interface INotaFiscalObservacoesBuilder 
    {
        INotaFiscalClienteBuilder ComObservacoes(string observacoes);
    }

    interface INotaFiscalClienteBuilder
    {
        INotaFiscalBuilder ComoCliente(Cliente cliente);
    }

    interface INotaFiscalItensBuilder  
    {
        INotaFiscalBuilder ComItem(Item item);
    }



    class NotaFiscalBuilder : INotaFiscalBuilder
        , INotaFiscalClienteBuilder, INotaFiscalCNPJBuilder, INotaFiscalEmissaoBuilder, INotaFiscalImpostosBuilder, INotaFiscalItensBuilder
        , INotaFiscalObservacoesBuilder, INotaFiscalRazaoSocialBuilder
    {
        private NotaFiscal _nota;
        public NotaFiscalBuilder()
        {
            _nota = new NotaFiscal();
        }

        public NotaFiscal Build() => _nota;

        public INotaFiscalCNPJBuilder ComRazaoSocial(string razaoSocial)
        {
            _nota.RazaoSocial = razaoSocial;
            return this;
        }

        public INotaFiscalEmissaoBuilder ComCNPJ(string cnpj)
        {
            _nota.Cnpj = cnpj;
            return this;
        }

        public INotaFiscalImpostosBuilder ComDataEmissao(DateTime? dataEmissao = null)
        {
            _nota.DataDeEmissao = dataEmissao ?? DateTime.Now;
            return this;
        }

        public INotaFiscalObservacoesBuilder ComTotalImpostos(double impostos)
        {
            _nota.Impostos = impostos;
            return this;
        }

        public INotaFiscalClienteBuilder ComObservacoes(string observacoes)
        {
            _nota.Observacoes = observacoes;
            return this;
        }

        public INotaFiscalBuilder ComItem(Item item)
        {
            _nota.Itens.Add(item);
            return this;
        }
        public INotaFiscalBuilder ComoCliente(Cliente cliente)
        {
            _nota.Cliente = cliente;
            return this;
        }

        public void Reset()
        {
            _nota = new NotaFiscal();
        }
    }
}
