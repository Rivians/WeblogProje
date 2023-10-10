using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.ViewComponents.Writer
{
	public class WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		public IViewComponentResult Invoke()
		{
			var values = writerManager.GetWriterById(1);
			return View(values);
		}
	}
}
