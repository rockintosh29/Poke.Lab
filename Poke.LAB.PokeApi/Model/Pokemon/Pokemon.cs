using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.PokeApi.Model.Pokemon
{
    public class PokemonByNameOrID : BaseResult
    {
        public int base_experience { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string? name { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public PokemonSprites? sprites { get; set; }
    }

    public class PokemonSprites
    {
        public string? front_default { get; set; }
        public string? back_default { get; set; }
    }
}
