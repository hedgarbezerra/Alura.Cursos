using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder
{
    interface IItemBuilder
    {
        void Reset();
        Item Build();
    }

    interface IItemBuilderNome
    {
        IItemBuilderValor Como(string nome);
    }

    interface IItemBuilderValor
    {
        IItemBuilder ComPreco(double valor);
    }

    class ItemBuilder : IItemBuilder, IItemBuilderNome, IItemBuilderValor
    {
        private Item _item;
        public ItemBuilder()
        {
            _item = new Item();
        }
        public Item Build() => _item;

        public IItemBuilderValor Como(string nome)
        {
            _item.Nome = nome;
            return this;
        }

        public IItemBuilder ComPreco(double valor)
        {
            _item.Valor = valor;
            return this;
        }

        public void Reset()
        {
            _item = new Item();
        }
    }
}
