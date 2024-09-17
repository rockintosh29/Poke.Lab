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
        public async Task GetPokemonByIdOrName()
        {
            Console.WriteLine("Probando método GetPokemonByIdOrName");

            for (int i = 1; i <= 10; i++)
            {
                var result = await _pokemonService.GetFromApiPokemonToDbByIdOrName(i);
                Assert.IsNotNull(result);


                Console.WriteLine($"{JsonConvert.SerializeObject(result)}");
            }
        }
        [TestMethod]
        public async Task GetNatureByIdOrName()
        {
            Console.WriteLine("Probando método GetNatureByIdOrName");

            for (int i = 1; i <= 10; i++)
            {
                var result = await _pokemonService.GetFromApiPokemonToDbByIdOrName(i);
                Assert.IsNotNull(result);


                Console.WriteLine($"{JsonConvert.SerializeObject(result)}");
            }
        }
    }
}
