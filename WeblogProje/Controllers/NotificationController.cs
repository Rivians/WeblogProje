﻿using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class NotificationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
