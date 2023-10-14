using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WeblogProje.Controllers
{
	public class BlogController : Controller
	{
		CommentManager commentm = new CommentManager(new EfCommentRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{		
			var values = bm.GetBlogListWithCategory();
			return View(values);
		}
		
		public IActionResult BlogReadAll(int id)
		{
			ViewBag.CommentCount = commentm.GetCommentCountByBlogCm(id);
			ViewBag.Id = id;
			var values = bm.GetBlogByID(id);
			return View(values);
		}

		public IActionResult BlogListByWriter()
		{
			var values = bm.GetListWithCategoryByWriter(1);
			return View(values);
		}

		[HttpGet]
		public IActionResult BlogAdd()
		{
			ViewBag.kategoriler = cm.GetList();
			return View();
		}

		[HttpPost]
		public IActionResult BlogAdd(Blog b)
		{
			BlogValidator bv = new BlogValidator();
			ValidationResult result = bv.Validate(b);
			if(result.IsValid)
			{
				b.BlogStatus = true;
				b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				b.WriterID = 1;
				bm.TAdd(b);
				return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult BlogDelete(int id)
		{
			var value = bm.TGetByID(id);
			bm.TDelete(value);
			return RedirectToAction("BlogListByWriter");
		}

		[HttpGet]
		public IActionResult BlogEdit(int id)
		{
			var values = bm.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult BlogEdit(Blog b)
		{
			BlogValidator bv = new BlogValidator();
			ValidationResult result = bv.Validate(b);
			if (result.IsValid)
			{
				bm.TUpdate(b);
				return RedirectToAction("BlogListByWriter");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
