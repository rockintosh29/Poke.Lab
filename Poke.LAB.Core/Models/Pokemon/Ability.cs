using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.Core.Models.Pokemon
{
    public class AbilityResult : BaseResult
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public bool Is_Main_Series { get; set; }

    }
}
