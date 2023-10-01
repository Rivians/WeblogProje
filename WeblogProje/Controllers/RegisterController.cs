using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			writer.WriterStatus = true;
			writer.WriterAbout = "deneme";
			wm.WriterAdd(writer);
			return RedirectToAction("Index", "Blog");
		}
	}
}
