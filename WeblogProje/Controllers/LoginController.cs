using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WeblogProje.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Writer w)
		{
			Context c = new Context();
			var data = c.Writers.FirstOrDefault(x => x.WriterEmail == w.WriterEmail && x.WriterPassword == w.WriterPassword);
			if(data != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, w.WriterEmail)
				};
				var userIdentity = new ClaimsIdentity(claims,"a");   // buraya nede a parametresi girdik ?
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}

			// Context c = new Context();
			// var data = c.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);
			// if (data != null)
			// {
			//		HttpContext.Session.SetString("username", writer.WriterEmail);
			//		return RedirectToAction("Index", "Writer");
			//	}
			//	else
			//	{
			//		return View();
			//	}

		}
	}
}
