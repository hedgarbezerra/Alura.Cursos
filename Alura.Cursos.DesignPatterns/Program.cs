using Alura.Cursos.DesignPatterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Alura.Cursos.DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new NotaFiscalBuilder();
            var itemBuilder = new ItemBuilder();

            var nf = builder.Build();
            builder.Reset();
            var nf2 = builder.ComRazaoSocial("Empresa")
                .ComCNPJ("cnpjftop")
                .ComDataEmissao()
                .ComTotalImpostos(9)
                .ComObservacoes("valores nocivos")
                .ComoCliente(null)
                .Build();

            var itemConstruido = itemBuilder.Como("Xiaomi MI9 2019")
                .ComPreco(90)
                .Build();
            var nf3 = builder.ComRazaoSocial("Empresa 2")
                .ComCNPJ("cnpjftop2")
                .ComDataEmissao(new DateTime(2022, 10,19))
                .ComTotalImpostos(552.4)
                .ComObservacoes("valores elevadores")
                .ComoCliente(new Cliente("cliente", "cpf123", "SP", true))
                .ComItem(new Item("Xbox", 43.1))
                .ComItem(new Item("PC Gamer", 94.1))
                .ComItem(new Item("TV LG", 891.3))
                .ComItem(itemConstruido)
                .Build();

            Console.ReadKey();
        }
    }
}
