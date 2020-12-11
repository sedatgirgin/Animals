using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Animal: IEquatable<Animal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals([AllowNull] Animal other)
        {
            return Id == other.Id && Name == other.Name;
        }

    }
}
