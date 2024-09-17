using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.Core.Models.Pokemon
{
    public class PokemonResult : BaseResult
    {
        public string? Name { get; set; }
        public long Weight { get; set; }
        public long Height { get; set; }
        public long BaseExperience { get; set; }
        public long Order { get; set; }
    }
}
