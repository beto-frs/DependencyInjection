using Microsoft.Extensions.Configuration;
using System;

namespace Console_Testes
{
    public class Teste
    {
        ITeste2 teste2;
        private readonly IConfiguration configuration;
        public Teste()
        {

        }
        public Teste(IConfiguration config, ITeste2 test2)
        {
            configuration = config;
            teste2 = test2;

        }

        public void TesteMetodo()
        {
            var unico = configuration.GetSection("Name1").Value;
            //var arrayDados = configuration.GetSection("Array1:2").Value;
            var listaDados = configuration.GetSection("Lista1:DataConnection").Value;
            
            
            Console.WriteLine($"{unico} - Exibindo Valor único.\n");
            Console.WriteLine($"{listaDados} - Exbindo a Lista.\n");
            

            for (int i = 0; i < 5; i++)
            {
                Console.Write(configuration.GetSection($"Array1:{i}").Value);
                Console.WriteLine(" - Exibindo a Array");
            }

            teste2.TesteMetodo();
        }
    }
}
