using Alura.Cursos.DesignPatterns.ChainOfResponsibility.Clean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.ChainOfResponsibility
{
    internal class ValidadorUsuario
    {
        ValidacaoUsuarioBase _validadorBase;
        ValidacaoUsuarioBase _validadorNome;
        ValidacaoUsuarioBase _validadorSenha;
        ValidacaoUsuarioBase _validadorEmail;
        ValidacaoUsuarioBase _validadorDataNascimento;
        public ValidadorUsuario()
        {
            _validadorBase = new ValidacaoUsuario();
            _validadorNome = new ValidacaoNomeUsuario();
            _validadorSenha = new ValidacaoSenhaUsuario();
            _validadorEmail = new ValidacaoEmailUsuario();
            _validadorDataNascimento = new ValidacaoDataNascimentoUsuario();
        }
        public bool Validar(Usuario usuario)
        {
            _validadorBase.DefinirProximo(_validadorNome);
            _validadorNome.DefinirProximo(_validadorEmail);
            _validadorEmail.DefinirProximo(_validadorSenha);
            _validadorSenha.DefinirProximo(_validadorDataNascimento);

            return _validadorBase.Lidar(usuario);
        }

        public bool Validar2(Usuario usuario)
        {
            var validadorEncadeado = new CadeiaMultiplaValidadores(new ValidacaoUsuarioClean(), new ValidacaoNomeUsuarioClean());

            return validadorEncadeado.Lidar(usuario);
        }
    }
}
