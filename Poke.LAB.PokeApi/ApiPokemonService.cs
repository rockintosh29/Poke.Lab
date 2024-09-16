using Poke.LAB.PokeApi.Model;
using RestSharp;
using Newtonsoft.Json;

namespace Poke.LAB.PokeApi
{
    /// <summary>
    /// Pokémon
    /// </summary>
    public class ApiPokemonService
    {
        public async static Task<PokemonByNameOrID> GetPokemonSimpleData(string pokemonName)
        {
            await Task.CompletedTask;

            try
            {
                var function = $"pokemon/{pokemonName}";
                var client = new RestClient(Const.POKEAPI);
                var request = new RestRequest(function, Method.Get);
                //Headers
                request.AddHeader("Content-Type", "application/json");

                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    PokemonByNameOrID result = JsonConvert.DeserializeObject<PokemonByNameOrID>(response.Content!)!;

                    result.Success = true;
                    result.Message = $"Pokemon {pokemonName} consultado con éxito.";

                    return result;
                }
                else
                {
                    return new PokemonByNameOrID
                    {
                        Success = false,
                        Message = "Error externo al realizar la consulta."
                    };
                }
            }
            catch (Exception ex)
            {
                return new PokemonByNameOrID
                {
                    Success = false,
                    Message = "Error interno al realizar la consulta.",
                    ExceptionMessage = $"{ex.Message} - {ex.InnerException!.Message}"
                };
            }
        }
    }
}
