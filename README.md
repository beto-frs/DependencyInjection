# Injeção de Dependência ( D.I.)

Utilizando os seguintes pacotes Nugget

> Microsoft.Extensions.Configuration
>
> Microsoft.Extensions.Configuration.FileExtensions
>
> Microsoft.Extensions.Configuration.Json
>
> Microsoft.Extensions.ConfigurationDependencyInjection



### Program.cs

```C#
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

```

------



### Teste.cs

```C#
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

```

------



### Teste2.cs

```C#
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

```

------



### ITeste2.cs

```C#
namespace Console_Testes
{
    public interface ITeste2
    {
        public void TesteMetodo();
    }
}

```

------





### AppSettings.json

```json
{
  "Array1": [
    "email1@test.com - Classe 1",
    "email2@test.com - Classe 1",
    "email3@test.com - Classe 1",
    "email4@test.com - Classe 1",
    "email5@test.com - Classe 1"
  ],

  "Lista1": {
    "DataConnection": "ConnectionStringToSQLDatabase"
  },

  "Array2": [
    "email1@test.com - Classe 2",
    "email2@test.com - Classe 2",
    "email3@test.com - Classe 2",
    "email4@test.com - Classe 2",
    "email5@test.com - Classe 2"
  ],

  "Lista2": {
    "DataConnection": "ConnectionStringToSQLDatabase"
  },
  
  "Name1": "Roberto Silva - Classe 1",

  "Name2": "Roberto Silva - Classe 2"

}

```

------



### Screenshots

![](.\img\Classes.png)



![](.\img\Exec.png)