using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class ErrorPage : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
