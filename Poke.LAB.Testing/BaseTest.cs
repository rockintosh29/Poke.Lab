using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.LAB.Core.Interfaces;
using Poke.LAB.Core.Services;
using Poke.LAB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.Testing
{
    public abstract class BaseTest
    {
        protected IServiceProvider _serviceProvider { get; set; }
        protected ServiceCollection? servicesCollection { get; set; }

        [TestInitialize]
        public void Init()
        {
            servicesCollection = new ServiceCollection();
            servicesCollection.AddLogging();

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            servicesCollection.AddSingleton<IConfiguration>(configuration);

            //DBContexts
            servicesCollection.AddDbContext<PokemonContext>( options =>
                options.UseMySql(configuration.GetConnectionString("Pokemon"), 
                ServerVersion.AutoDetect(configuration.GetConnectionString("Pokemon")))
            );

            servicesCollection.AddTransient<IPokemonService, PokemonService>();
            _serviceProvider = servicesCollection.BuildServiceProvider();
        }
    }
}
