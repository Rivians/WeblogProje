using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.ViewComponents.Writer
{
	public class WriterNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
