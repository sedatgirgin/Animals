using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Caching
{
    public static class CacheKeys
    {
        public static string CallbackEntry { get { return "_AnimalList"; } }
        public static string CallbackMessage { get { return "_CallbackMessage"; } }
    }
}
