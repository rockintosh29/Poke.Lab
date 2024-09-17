using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poke.LAB.PokeApi
{
    public static class Const
    {
        /// <summary>
        /// HOST POKE API
        /// </summary>
        static string _POKEAPI_URL = null;
        public static string POKEAPI
        {
            get
            {
                if (_POKEAPI_URL == null)
                {
                    _POKEAPI_URL = "https://pokeapi.co/api/v2/";
                }
                return _POKEAPI_URL;
            }
        }
    }
}
