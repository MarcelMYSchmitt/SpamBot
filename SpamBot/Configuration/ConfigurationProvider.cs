using System;
using Microsoft.Extensions.Configuration;
    

namespace SpamBot.Configuration
{
    public class ConfigurationProvider
    {

        public IConfigurationRoot CreateConfiguration()
        {
            return CreateConfiguration(builder => { });
        }

        public IConfigurationRoot CreateConfiguration(Action<ConfigurationBuilder> configureAdditionalSources)
        {
            var builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables();
            configureAdditionalSources(builder);

            return builder.Build();
        }
    }
}