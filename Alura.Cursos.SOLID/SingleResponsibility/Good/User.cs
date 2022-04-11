using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.SOLID.SingleResponsibility.Good
{
    internal class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User() { }
        public User(Guid iD, string name, string email)
        {
            ID = iD;
            Name = name;
            Email = email;
        }
    }
}
