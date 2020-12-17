using Animals.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Validation
{
    public class WeightValidator : AbstractValidator<WeightDto>
    {
        public WeightValidator()
        {
            RuleFor(x => x.AnimalId).NotEmpty().WithMessage("AnimalId boş olamaz.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Lütfen zaman giriniz.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Kilo boş olamaz.");
        }
    }
}
