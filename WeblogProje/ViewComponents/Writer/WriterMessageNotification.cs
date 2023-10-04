using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{			
			return View();
		}
	}
}
