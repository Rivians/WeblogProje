using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogValidator : AbstractValidator<Blog>
	{
		public BlogValidator()
		{
			RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz !");
			RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Minimum başlık uzunluğu 5 karakterdir");
			RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Maximum başlık uzunluğu 150 karakterdir");

			RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz");
			RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Minimum kontent uzunluğu 5 karakterdir");

			RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
			RuleFor(x => x.BlogImage).MinimumLength(5).WithMessage("Minimum blog görsel url uzunluğu 5 karakterdir");

			RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog thumbnail'i boş geçemezsiniz");
			RuleFor(x => x.BlogThumbnailImage).MinimumLength(5).WithMessage("Minimum blog thumbnail url uzunluğu 5 karakterdir");

			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori türü boş geçilemez");


		}
	}
}
