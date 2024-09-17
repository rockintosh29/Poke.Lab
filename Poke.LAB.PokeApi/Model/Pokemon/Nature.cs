using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.PokeApi.Model.Pokemon
{
    public class NatureByNameOrID : BaseResult
    {
        public int id { get; set; }
        public string? name { get; set; }

    }
}
