using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Windows.Forms;
using WindowsFormsNetCore.Services;

namespace WindowsFormsNetCore
{
    public partial class SecondForm : Form
    {
        private readonly ISampleService sampleService;
        private readonly IConfiguration configuration;
        
        public SecondForm(ISampleService sample, IConfiguration conf)
        {
            InitializeComponent();

            sampleService = sample;
            configuration = conf;

            label1.Text = configuration.GetSection("Lista2:Lista2").Value;
            label2.Text = configuration.GetSection("Lista2:Resultado").Value;
        }

        private void SecondForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
