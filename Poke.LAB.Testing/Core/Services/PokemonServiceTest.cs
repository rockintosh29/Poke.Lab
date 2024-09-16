using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Poke.LAB.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.Testing.Core.Services
{
    [TestClass]
    public class PokemonServiceTest : BaseTest
    {
        private PokemonService _pokemonService;

        [TestInitialize]
        public void Initialize()
        {
            _pokemonService = ActivatorUtilities.CreateInstance<PokemonService>(_serviceProvider);
        }

        [TestMethod]
        public async Task HolaMundo()
        {
            await Task.CompletedTask;
            Console.WriteLine("Probando método HolaMundo");

            Console.WriteLine("HolaMundo");
        }

        [TestMethod]
        public async Task GetPokemonByIdOrName()
        {
            Console.WriteLine("Probando método GetPokemonByIdOrName");
            string pokemon = "gligar";

            for (int i = 1; i <= 10; i++)
            {
                var result = await _pokemonService.GetFromApiPokemonToDbByIdOrName(i.ToString());
                Assert.IsNotNull(result);


                Console.WriteLine($"{JsonConvert.SerializeObject(result)}");
            }
        }

        [TestMethod]
        public async Task ConsultPokemonInBD()
        {
            Console.WriteLine("Probando método ConsultPokemonInBD");
            string pokemon = "pikachu";

            var result = await _pokemonService.GetPokemonByName(pokemon);
            Assert.IsNotNull(result);

            Console.WriteLine($"{JsonConvert.SerializeObject(result)}");
        }
    }
}
