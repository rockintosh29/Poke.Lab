using Poke.LAB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poke.LAB.DAL;
using Poke.LAB.Core.Models;
using Poke.LAB.PokeApi;
using Poke.LAB.Core.Models.Pokemon;

namespace Poke.LAB.Core.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IConfiguration _config;
        private readonly PokemonContext _context;

        public PokemonService(IConfiguration config, PokemonContext context) 
        {
            _config = config;
            _context = context;
        }

        public async Task<BaseResult> GetFromApiPokemonToDbByIdOrName(string pokemonName)
        {
            await Task.CompletedTask;

            //Consumir API
            var pokemon = await ApiPokemonService.GetPokemonSimpleData(pokemonName);

            if (!pokemon.Success)
            {
                return new BaseResult
                {
                    Success = pokemon.Success,
                    Message = pokemon.Message   
                };
            }

            var newPokemon = new DAL.Models.Pokemon
            {
                Name = pokemon.name,
                PokeAPI_ID = pokemon.id,
                Weight = pokemon.weight,
                Height = pokemon.height,
                IsDefault = pokemon.is_default,
                Order = pokemon.order,  
                BaseExperience = pokemon.base_experience
            };

            _context.Pokemon.Add(newPokemon);
            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = pokemon.Message,
            };
        }
        /*
        1.Recibir el nombre del pokemon que quiero consultar en mi BD. ***
        1.1 Por medio de un parametro.
        2.Hacer la consulta a la BD. ***
        3.Hacer el mapeo de datos. ***
        3.1 Definir modelo de salida (Result)
        3.2 Mapear salida con consulta
        4.Mostrar la información ****/
        public async Task<PokemonResult> GetPokemonByName(string pokemonName)
        {
            await Task.CompletedTask;

            var consulta = await _context.Pokemon
                .Where(p => p.Name == pokemonName)
                .FirstOrDefaultAsync();

            if (consulta == null)
            {
                return new PokemonResult
                {
                    Success = true,
                    Message = "Pokemon no encontrado en la BD."
                };
            }

            var resultado = new PokemonResult
            {
                Success = true,
                Message = "",
                Name = consulta.Name,
                Weight = consulta.Weight,
                Height = consulta.Height,
                Order = consulta.Order,
                BaseExperience = consulta.BaseExperience
            };

            return resultado;
        }
    }
}
