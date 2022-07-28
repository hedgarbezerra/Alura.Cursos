using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Alura.Cursos.DesignPatterns.Prototype
{
    public static class PrototypeHelper
    {
        public static T CreateDeepCopy<T>(T obj)
        {
            var str = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(str);

        }
    }
}
