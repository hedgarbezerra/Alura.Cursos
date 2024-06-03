using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Builder.Novo
{
    public class Exemplo
    {

        // O builder do produto é mais flexível que permite a iniciação através da interface IProdutoBuilder que permite
        //definir tanto o nome quanto o valor do produto, que ambos permitiram a alteração do outro e a criação de uma instância
        public void CriaProduto()
        {
            var produto = ProdutoBuilder.New()
                .WithName("GTX 1660")
                .WithValue(1449)
                .Build();

            var produto2 = ProdutoBuilder.New()
                .WithValue(555649)
                .WithName("IPhone 1653948")
                .Build();
        }

        // Os builders abaixos não são tão flexíveis pois usam o pattern fluent API de forma restritiva,
        //permitando que as chamadas encadeadas sejam feitas para definir as propriedades de forma DEFINIDA e não flexível
        public void CriaCliente()
        {
            var cliente = ClienteBuilder.New()
                .WithName("Hedgar")
                .WithEmail("huqwewe@gmail.com")
                .WithBirthdate(new DateTime(2000, 01, 01))
                .Build();
        }

        public void CriaEndereco()
        {
            var endereco = EnderecoBuilder.New()
                .WithAddress("Av.Teste")
                .WithCEP(1289231)
                .WithState("")
                .Build();

            var endereco2 = EnderecoBuilder.New()
                .WithAddress("Av.Teste")
                .Build();
        }

        public void CriaPedido()
        {
            var pedido1 = PedidoBuilder.New()
                .WithClient(c => c.WithName("Carlito")
                    .WithEmail("Carlito")
                    .WithBirthdate(new DateTime(2022, 01, 02)))
                .WithDeliveryAddress(a => a.WithAddress("Av. asji")
                    .WithCEP(112782)
                    .WithState("SP"))
                .HasProduct(p => p.WithName("P1")
                    .WithValue(12.33m))
                .HasProduct(p => p.WithName("P2")
                    .WithValue(993.3M))
                .WithObservation("NA")
                .Build();
        }
    }
}
