using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder.Novo
{
    #region Produto
    public class ProdutoBuilder : IProdutoBuilder
    {
        private string _nome;
        private decimal _valor;

        private ProdutoBuilder()
        {
            _nome = string.Empty;
            _valor = 0;
        }

        public Produto Build() => new Produto() { Nome = _nome, Preco = _valor };
        public static IProdutoBuilder New()
        {
            return new ProdutoBuilder();
        }

        public ITemValorProdutoBuilder WithName(string nome)
        {
            _nome = nome;
            return this;
        }

        public ITemNomeProdutoBuilder WithValue(decimal valor)
        {
            _valor = valor;
            return this;
        }
    }
    #endregion

    #region Cliente
    public class ClienteBuilder : IClienteBuilder
    {
        private string _nome;
        private string _email;
        private DateTime _birthdate;

        private ClienteBuilder()
        {
            _nome = string.Empty;
            _email = string.Empty;
            _birthdate = DateTime.MinValue;
        }
        public static INomeClienteBuilder New() => new ClienteBuilder();

        public Cliente Build() => new Cliente { Email = _email, Nome = _nome, DataNascimento = _birthdate };

        public IEmailClienteBuilder WithName(string nome)
        {
            _nome = nome;
            return this;
        }

        public IDataNascimentoClienteBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }
        public IBuilder<Cliente> WithBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
            return this;
        }
    }
    #endregion

    #region Endereco

    public class EnderecoBuilder : IEnderecoBuilder
    {
        private string _address;
        private int _cep;
        private string _estado;
        private EnderecoBuilder()
        {
            _address = string.Empty;
            _cep = 0;
            _estado = string.Empty;
        }

        public static ITemLogradouroEnderecoBuilder New() => new EnderecoBuilder();
        public Endereco Build() => new Endereco() { Logradouro = _address, CEP = _cep, Estado = _estado };

        public ITemCEPEnderecoBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public ITemEstadoEnderecoBuilder WithCEP(int cep)
        {
            _cep = cep;
            return this;
        }

        public IBuilder<Endereco> WithState(string state)
        {
            _estado = state;
            return this;
        }
    }
    #endregion

    #region Pedido

    public class PedidoBuilder : IPedidoBuilder
    {
        private Cliente _cliente;
        private Endereco _endereco;
        private List<Produto> _produtos;
        private string _observacoes;

        private readonly ClienteBuilder _clienteBuilder;
        private readonly EnderecoBuilder _enderecoBuilder;
        private readonly ProdutoBuilder _produtoBuilder;
        private PedidoBuilder()
        {
            _cliente = new Cliente();
            _endereco = new Endereco();
            _produtos = new List<Produto>();
            _observacoes = string.Empty;

            _clienteBuilder = ClienteBuilder.New() as ClienteBuilder;
            _enderecoBuilder = EnderecoBuilder.New() as EnderecoBuilder;
            _produtoBuilder = ProdutoBuilder.New() as ProdutoBuilder;
        }
        public static ITemClienteBuilder New() => new PedidoBuilder();
        public Pedido Build() => new Pedido() { Cliente = _cliente, EnderecoEntrega = _endereco, Observacoes = _observacoes, Produtos = _produtos };


        public ITemEnderecoBuilder WithClient(Cliente cliente)
        {
            _cliente = cliente;
            return this;
        }

        public ITemEnderecoBuilder WithClient(Action<INomeClienteBuilder> buildingAction)
        {
            buildingAction?.Invoke(_clienteBuilder);
            _cliente = _clienteBuilder.Build();
            return this;
        }

        public ITemEnderecoBuilder WithDeliveryAddress(Endereco address)
        {
            _endereco = address;
            return this;
        }

        public ITemEnderecoBuilder WithDeliveryAddress(Action<ITemLogradouroEnderecoBuilder> buildingAction)
        {
            buildingAction?.Invoke(_enderecoBuilder);

            _endereco = _enderecoBuilder.Build();
            return this;
        }

        public ITemObservacao HasProduct(Produto product)
        {
            _produtos.Add(product);
            return this;
        }

        public ITemObservacao HasProduct(Action<IProdutoBuilder> buildingAction)
        {
            buildingAction?.Invoke(_produtoBuilder);

            var produto = _produtoBuilder.Build();
            _produtos.Add(produto);

            return this;
        }

        public IBuilder<Pedido> WithObservation(string observation)
        {
            _observacoes = observation;
            return this;
        }
    }
    #endregion
}
