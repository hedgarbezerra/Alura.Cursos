using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Cursos.DesignPatterns.Factory
{
    class FactoryConnectionString
    {

        public string GetConnectionString()
        {
            var filesDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent
                .Parent
                .Parent
                .Parent
                .GetFiles()
                .First(f => string.Equals(f.Name, "Dados.Txt", StringComparison.InvariantCultureIgnoreCase)).FullName; ;
            var arquivoConfig = File.ReadAllLines(filesDir);
            var connectionString = arquivoConfig.FirstOrDefault(linha =>
            {
                var name = linha.Split('/')[0];
                return name == "ConnectionString";
            });

            if (!string.IsNullOrEmpty(connectionString))
                return connectionString.Split('/')[1];
            throw new Exception("ConnectionString Not Found");
        }
        private class Config
        {
            public string User { get; set; }
        }
    }
}
