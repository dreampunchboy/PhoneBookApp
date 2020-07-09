using Microsoft.Extensions.Configuration;
using PhoneBookApp.App.App;
using System;
using System.IO;

namespace PhoneBookApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = configure(args);

            var mainView = new MainView(configuration);
            mainView.Start();
        }

        /// <summary>
        /// Get the config from the json config
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static IConfiguration configure(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("app.json", optional: true, reloadOnChange: true)
            .AddCommandLine(args)
            .Build();

            return configuration;
        }
    }
}
