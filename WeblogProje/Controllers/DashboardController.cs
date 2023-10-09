using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
