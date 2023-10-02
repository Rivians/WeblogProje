using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
