using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult PartialAddComment(Comment c)
		{
			c.BlogID = 7;
			c.CommentStatus = true;
			c.CommentDate = DateTime.Parse(DateTime.Now.ToString("dd,MMM,yyyy"));
			cm.CommentAdd(c); 
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}
