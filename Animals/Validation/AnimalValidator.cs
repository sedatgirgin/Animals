﻿using Animals.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Validation
{
    public class AnimalValidator : AbstractValidator<AnimalDto>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen isim giriniz..");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId boş olamaz giriniz..");
            RuleFor(x => x.AnimalSpeciesId).NotEmpty().WithMessage("AnimalSpeciesId boş olamaz giriniz..");
        }
    }
}
