using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeblogProje.Models;

namespace WeblogProje.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Test()
		{
			return View();
		}

		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var values = wm.TGetByID(1);	
			return View(values);
		}

		[HttpPost]
		public IActionResult WriterEditProfile(Writer p)
		{
			WriterValidator wl = new WriterValidator();
			ValidationResult result = wl.Validate(p);
			if(result.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage p)
		{
			Writer w = new Writer();
			if(p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);	// FileName prop'u p.WriterImage'in bilgilerini tutar. >> web form üzerinden seçilen dosyanın uzatısını almak istediğimizde ise Path.GetExtension'u kullanırız.
				var newImageName = Guid.NewGuid().ToString() + extension;	// Guid - Globally Unique Identifier >>> NewGuid() diyerek benzersizliği garanti eden 128 bitlik rastgele bir dizi oluşturur. Bunu isim olarak kullanacağız.
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);  // Path.Combine() dosya yükleme islemlerinde tam bir path yani dosya dizini olusturmak için elimizdeki verileri birleştirmemizi sağlayan bir metottur.
				var stream = new FileStream(location, FileMode.Create);		// FileStream class'ından yeni bir nesne olusturuyoruz. FileMode.Create , dosyanın eğer varsa üzerine yazılacağını ve eğer yoksa yeni bir dosya oluşturulacağını ifade eder.
				
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newImageName;
			}
			w.WriterEmail = p.WriterEmail;		
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;

			wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
		}
	}
}
