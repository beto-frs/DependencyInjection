using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Console_Testes
{
    class Program
    {
     
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            IConfiguration configuration;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSettings.json")
                .Build();

            serviceCollection
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<Teste>()
                .AddSingleton<ITeste2, Teste2>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testInstance = serviceProvider.GetService<Teste>();

            testInstance.TesteMetodo();
        }
        
    }
}
