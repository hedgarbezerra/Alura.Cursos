using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder.Novo
{
    public class Pedido
    {
        public string Observacoes { get; init; }
        public decimal Total { get => Produtos.Sum(p => p.Preco); }
        public Endereco EnderecoEntrega { get; init; }
        public Cliente Cliente { get; init; }
        public List<Produto> Produtos { get; init; }
    }

    
    public class Cliente
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public DateTime DataNascimento { get; init; }
    }

    public class Endereco
    {
        public int CEP { get; init; }
        public string Logradouro { get; init; }
        public string Estado { get; init; }
    }
    public class Produto
    {
        public string Nome { get; init;}
        public decimal Preco { get; init; }
    }
}
