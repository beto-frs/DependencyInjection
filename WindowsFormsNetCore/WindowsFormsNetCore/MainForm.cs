using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Windows.Forms;
using WindowsFormsNetCore.Services;

namespace WindowsFormsNetCore
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ISampleService sampleService;
        private readonly IConfiguration configuration;

        public MainForm(IServiceProvider serviceProvider, ISampleService sampleService, IConfiguration conf)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            this.sampleService = sampleService;
            configuration = conf;
            label1.Text = (configuration.GetSection($"Lista1:Resultado").Value).ToString();
        }

        private void OpenSecondFormButton_Click(object sender, EventArgs e)
        {
            var form = serviceProvider.GetRequiredService<SecondForm>();
            form.ShowDialog(this);
            

        }
    }
}
