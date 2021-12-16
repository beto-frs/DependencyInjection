using Microsoft.Extensions.Configuration;
using System;

namespace Console_Testes
{
    public class Teste2 : ITeste2
    {
        IConfiguration configuration;
        

        public Teste2(IConfiguration config)
        {
            configuration = config;
            
        }

        public void TesteMetodo()
        {
            var unico = configuration.GetSection("Name2").Value;
            var arrayDados = configuration.GetSection("Array2:1").Value;
            var listaDados = configuration.GetSection("Lista2:DataConnection").Value;


            Console.WriteLine($"{unico} - Exibindo Valor único.\n");
            Console.WriteLine($"{listaDados} - Exbindo a Lista.\n");


            for (int i = 0; i < 5; i++)
            {
                Console.Write(configuration.GetSection($"Array2:{i}").Value);
                Console.WriteLine(" - Exibindo a Array");
            }

            

        }
    }
}
