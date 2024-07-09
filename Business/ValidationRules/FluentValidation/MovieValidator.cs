using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.MovieName).NotEmpty().WithMessage("Film ismi boş bırakılamaz!");
            RuleFor(m => m.MovieName).MinimumLength(2).WithMessage("Film ismi 2 karakterden daha az olamaz!");
            RuleFor(m => m.MovieName).MaximumLength(100).WithMessage("Film ismi 100 karakterden daha fazla olamaz!");
            RuleFor(m => m.Description).NotEmpty().WithMessage("Film açıklaması boş bırakılamaz!");
            RuleFor(m => m.Description).MinimumLength(5).MaximumLength(200)
                .WithMessage("Film açıklaması 5 ile 200 karakter arasında olmalıdır!");
            RuleFor(m => m.TrailerUrl).NotEmpty().WithMessage("Film url bilgisi boş bırakılamaz!");
        }
    }
}
