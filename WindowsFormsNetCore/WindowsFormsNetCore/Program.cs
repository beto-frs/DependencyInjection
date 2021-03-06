using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using WindowsFormsNetCore.Services;

namespace WindowsFormsNetCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                            .ConfigureAppConfiguration((context, builder) =>
                            {
                                // Add other configuration files...
                                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                            })
                            .ConfigureServices((context, services) =>
                            {
                                ConfigureServices(context.Configuration, services);
                            })
                            .ConfigureLogging(logging =>
                            {
                                // Add other loggers...
                            })
                            .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            //services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<ISampleService, SampleService>();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<MainForm>();
            services.AddTransient<SecondForm>();
        }
    }
}
