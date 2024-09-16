using Poke.LAB.Core.Models;
using Poke.LAB.Core.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.Core.Interfaces
{
    public interface IPokemonService
    {
        Task<BaseResult> GetFromApiPokemonToDbByIdOrName(string pokemonName);
        Task<PokemonResult> GetPokemonByName(string pokemonName);
    }
}
