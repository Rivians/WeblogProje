using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı kısmı boş geçilemez.");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Yazar email kısmı boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifre kısmı boş geçilemez.");

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girin.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girin.");
        }
    }
}
