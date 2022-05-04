using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo
{
    public class ProgramConfiguration
    {
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
    }

    public class ConfigurationHelper
    {
        private static ConfigurationHelper instance;

        private IConfiguration configuration;

        private ConfigurationHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public T GetProperty<T>(string propertyName)
        {
            return this.configuration.GetValue<T>(propertyName);
        }

        public T GetConfiguration<T>()
        {
            var section = this.configuration.GetSection(typeof(T).Name);
            var config = section.Get<T>(o => o.BindNonPublicProperties = true);
            return config;
        }

        public static ConfigurationHelper GetInstance(IConfiguration configuration)
        {
            if (instance == null)
            {
                instance = new ConfigurationHelper(configuration);
            }
            return instance;
        }
    }

}
