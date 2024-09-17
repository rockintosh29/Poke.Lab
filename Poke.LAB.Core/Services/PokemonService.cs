using Poke.LAB.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poke.LAB.DAL;
using Poke.LAB.Core.Models;
using Poke.LAB.PokeApi;
using Poke.LAB.Core.Models.Pokemon;
using Poke.LAB.DAL.Models;

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

        //Pokemon
        public async Task<BaseResult> GetFromApiPokemonToDbByIdOrName(int pokemonId)
        {
            await Task.CompletedTask;

            //Consumir API
            var pokemon = await ApiPokemonService.GetPokemonSimpleData(pokemonId);

            if (!pokemon.Success)
            {
                return new BaseResult
                {
                    Success = pokemon.Success,
                    Message = pokemon.Message   
                };
            }

            if (_context.Pokemon.Any(p => p.PokeAPI_ID == pokemon.id))
            {
                return new BaseResult
                {
                    Success = true,
                    Message = $"Pokémon {pokemon.name} ya registrado en la BD."
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
        public async Task<PokemonResult> GetPokemonById(int pokemonId)
        {
            await Task.CompletedTask;

            var consulta = await _context.Pokemon
                .Where(p => p.PokeAPI_ID == pokemonId)
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
        //Naturaleza
        public async Task<BaseResult> GetFromApiNatureToDbByIdOrName(int natureId)
        {
            await Task.CompletedTask;
            var nature = await ApiPokemonService.GetNatureSimpleData(natureId);

            if (!nature.Success)
            {
                return new BaseResult
                {
                    Success = nature.Success,
                    Message = nature.Message
                };
            }

            if (_context.Nature.Any(n => n.PokeAPI_ID == nature.id))
            {
                return new BaseResult
                {
                    Success = true, 
                    Message = $"Naturaleza {nature.name} ya registrada en la BD."
                };
            }

            var newNature = new DAL.Models.Nature
            {
                Name = nature.name,
                PokeAPI_ID = nature.id
            };

            _context.Nature.Add(newNature);
            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = nature.Message
            };
        }
        public async Task<NatureResult> GetNatureById(int natureId)
        {
            await Task.CompletedTask;

            var consulta = await _context.Pokemon
                .Where(p => p.PokeAPI_ID == natureId)
                .FirstOrDefaultAsync();

            if (consulta == null)
            {
                return new NatureResult
                {
                    Success = true,
                    Message = "Naturaleza no encontrada en la BD."
                };
            }

            var resultado = new NatureResult
            {
                Success = true,
                Message = "",
                Name = consulta.Name,
                ID = consulta.PokeAPI_ID
            };

            return resultado;
        }

    }
}
