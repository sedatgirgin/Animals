using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Animals.Models
{
    public class User: IdentityUser
    {
        public List< Animal> Animal { get; set; }

    }
}
