using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.SingleResponsibility.Bad
{
    internal class User
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User() {}
        public User(Guid iD, string name, string email)
        {
            ID = iD;
            Name = name;
            Email = email;
        }

        private Guid GenerateRandomGuid() => Guid.NewGuid();

        public void Insert(User user)
        {

        }
        public void Update(User user)
        {

        }
        public void Delete(User user)
        {

        }
        public void Select(Guid id)
        {

        }

        public void MailTo(User remetent, User Receipient, string message)
        {

        }
    }
}
