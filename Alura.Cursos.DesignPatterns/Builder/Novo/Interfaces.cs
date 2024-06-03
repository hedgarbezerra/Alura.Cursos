using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder.Novo
{
    public interface IBuilder<T>
    {        
        T Build();
    }

    #region Produto

    public interface IProdutoBuilder : ITemNomeProdutoBuilder, ITemValorProdutoBuilder
    {
    }

    public interface ITemNomeProdutoBuilder : IBuilder<Produto>
    {
        ITemValorProdutoBuilder WithName(string nome);
    }

    public interface ITemValorProdutoBuilder : IBuilder<Produto>
    {
        ITemNomeProdutoBuilder WithValue(decimal valor);
    }
    #endregion

    #region Cliente

    public interface IClienteBuilder : INomeClienteBuilder, IEmailClienteBuilder, IDataNascimentoClienteBuilder
    {
    }
    public interface INomeClienteBuilder : IBuilder<Cliente>
    {
        IEmailClienteBuilder WithName(string nome);
    }
    public interface IEmailClienteBuilder : IBuilder<Cliente>
    {
        IDataNascimentoClienteBuilder WithEmail(string email);
    }
    public interface IDataNascimentoClienteBuilder : IBuilder<Cliente>
    {
        IBuilder<Cliente> WithBirthdate(DateTime birthdate);
    }
    #endregion

    #region Endereco

    public interface IEnderecoBuilder : ITemLogradouroEnderecoBuilder, ITemCEPEnderecoBuilder, ITemEstadoEnderecoBuilder
    {
    }

    public interface ITemLogradouroEnderecoBuilder : IBuilder<Endereco>
    {
        ITemCEPEnderecoBuilder WithAddress(string address);
    }

    public interface ITemCEPEnderecoBuilder : IBuilder<Endereco>
    {
        ITemEstadoEnderecoBuilder WithCEP(int cep);
    }
    public interface ITemEstadoEnderecoBuilder : IBuilder<Endereco>
    {
        IBuilder<Endereco> WithState(string state);
    }
    #endregion

    #region Pedido
    public interface IPedidoBuilder : ITemClienteBuilder, ITemEnderecoBuilder, ITemProdutoBuilder, ITemObservacao
    {
    }

    public interface ITemClienteBuilder : IBuilder<Pedido>, ITemProdutoBuilder
    {
        ITemEnderecoBuilder WithClient(Cliente cliente);
        ITemEnderecoBuilder WithClient(Action<INomeClienteBuilder> buildingAction);
    }

    public interface ITemEnderecoBuilder : IBuilder<Pedido>, ITemProdutoBuilder
    {
        ITemProdutoBuilder WithDeliveryAddress(Endereco address);
        ITemProdutoBuilder WithDeliveryAddress(Action<ITemLogradouroEnderecoBuilder> buildingAction);
    }

    public interface ITemProdutoBuilder : IBuilder<Pedido>
    {
        ITemObservacao HasProduct(Produto product);
        ITemObservacao HasProduct(Action<IProdutoBuilder> buildingAction);

    }

    public interface ITemObservacao : IBuilder<Pedido>, ITemProdutoBuilder
    {
        IBuilder<Pedido> WithObservation(string observation);
    }

    #endregion

}
