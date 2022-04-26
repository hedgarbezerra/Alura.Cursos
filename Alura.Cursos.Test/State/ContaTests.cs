using Alura.Cursos.DesignPatterns.State;
using Moq;
using NUnit.Framework;
using System;

namespace Alura.Cursos.Test.State
{
    [TestFixture]
    public class ContaTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Conta CreateConta()
        {
            return new Conta();
        }

        [Test]
        public void Saca_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var conta = this.CreateConta();
            double valor = 0;

            // Act
            conta.Saca(
                valor);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Deposita_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var conta = this.CreateConta();
            double valor = 0;

            // Act
            conta.Deposita(
                valor);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
