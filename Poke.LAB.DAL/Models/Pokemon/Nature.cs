using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.DAL.Models.Pokemon
{
    public class Nature : BaseModel
    {
        [Key]
        public long NatureID { get; set; }
        public long PokeAPI_ID { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
