using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.DAL.Models
{
    public class Pokemon : BaseModel
    {
        [Key]
        public long PokemonID { get; set; } 
        public long PokeAPI_ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public long BaseExperience { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public long Order { get; set; }
        public bool IsDefault { get; set; }

        public PokemonSprites? Sprites { get; set; }    
    }

    public class PokemonSprites
    {
        [Key]
        public long PokeSpriteID { get; set; }
        [Required]
        public long PokemonID { get; set; }
        public Pokemon? Pokemon { get; set; }
        public string? Front { get; set; }   
        public string? Back { get; set; }
    }

    public class Nature : BaseModel
    {
        [Key]
        public long NatureID { get; set; }
        public long PokeAPI_ID { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
