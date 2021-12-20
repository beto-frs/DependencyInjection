using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace WindowsFormsNetCore.Services
{
    public class SampleService : ISampleService
    {
        IConfiguration configuration;
        public string GetCurrentDate()
        {
            return DateTime.Now.ToLongDateString();
        }
        
    }
}
