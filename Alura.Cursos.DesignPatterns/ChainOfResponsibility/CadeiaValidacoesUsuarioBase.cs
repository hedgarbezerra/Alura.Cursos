using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility
{
    internal abstract class ValidacaoUsuarioBase : CadeiaGenerica<ValidacaoUsuarioBase, bool>
    {
        public override bool Lidar(params object[] parametros)
        {
            var usuario = parametros.FirstOrDefault() as Usuario;
            if (Validar(usuario))
                return Proximo is null ? true : Proximo.Lidar(usuario);
            return false;
        }

        protected abstract bool Validar(Usuario usuario);
    }
    internal class ValidacaoUsuario : ValidacaoUsuarioBase
    {
        protected override bool Validar(Usuario usuario)
        {
            bool result = usuario is not null;
            string resultText = result ? "Aprovado" : "Rejeitado";
            Console.WriteLine($"Ao Validar a existencia do usuário o resultado foi: {resultText}");
            return result;
        }
    }
    internal class ValidacaoEmailUsuario : ValidacaoUsuarioBase
    {
        protected override bool Validar(Usuario usuario)
        {
            bool result = !string.IsNullOrEmpty(usuario.Email);
            string resultText = result ? "Aprovado" : "Rejeitado";
            Console.WriteLine($"Ao Validar o email o resultado foi: {resultText}");

            return result;
        }
    }
    internal class ValidacaoNomeUsuario : ValidacaoUsuarioBase
    {
        protected override bool Validar(Usuario usuario)
        {
            bool result = !string.IsNullOrEmpty(usuario.Nome);
            string resultText = result ? "Aprovado" : "Rejeitado";
            Console.WriteLine($"Ao Validar o nome o resultado foi: {resultText}");

            return result;
        }

    }
    internal class ValidacaoSenhaUsuario : ValidacaoUsuarioBase
    {
        protected override bool Validar(Usuario usuario)
        {
            bool result = !string.IsNullOrEmpty(usuario.Senha) && usuario.Senha.Length > 8;
            string resultText = result ? "Aprovado" : "Rejeitado";
            Console.WriteLine($"Ao Validar a senha o resultado foi: {resultText}");

            return result;
        }
    }
    internal class ValidacaoDataNascimentoUsuario : ValidacaoUsuarioBase
    {
        protected override bool Validar(Usuario usuario)
        {
            bool result = usuario.DataNascimento > DateTime.MinValue &&
                usuario.DataNascimento < DateTime.MaxValue &&
                (DateTime.Today.Year - usuario.DataNascimento.Year) > 18;
            string resultText = result ? "Aprovado" : "Rejeitado";
            Console.WriteLine($"Ao Validar a data de nascimento o resultado foi: {resultText}");

            return result;
        }
    }
}
