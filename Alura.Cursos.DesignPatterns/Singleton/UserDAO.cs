using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Singleton
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class UserDAO
    {
        public User GetUser(int userId) => new User();
        public IList<User> GetUsers() => Enumerable.Empty<User>().ToList();
    }

    class UserDataSingleton
    {
        private static UserDAO _userDAO;
        public static UserDAO Instance
        {
            get
            {
                if (_userDAO is null)
                {
                    _userDAO = new UserDAO();
                }
                return _userDAO;
            }
        }
    }

    class SingletonTest
    {
        private void Test()
        {
            //cenário onde durante o fluxo do código uma classe pudesse ser instânciada diversas vezes:
            //foram criadas duas instância da UserDAO desnecessariamente
            var user = new UserDAO().GetUser(1);
            var otherUser = new UserDAO().GetUser(2);
            Console.WriteLine(user == otherUser);

            //Ideal para manter uma única instância sem consumo elevado de memória
            var userFinal = UserDataSingleton.Instance.GetUser(1);
        }
    }
}
