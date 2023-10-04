using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class WriterController : Controller
	{
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
	}
}
