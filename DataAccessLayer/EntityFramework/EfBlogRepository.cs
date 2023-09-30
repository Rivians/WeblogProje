using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		public List<Blog> GetListWithCategory()
		{
			using(var c = new Context())
			{
				// Buradaki Include metodu, Entity Framework tarafından sunulan bir işlemdir ve bu kod parçası verileri yükleme (eager loading) işlemini gerçekleştirir.
				// Blogs tablosundaki her bir blog nesnesini çekerken, ilişkili Category tablosundaki verileri de çeker. Bu, daha sonra kullanılacak olan bu verilere erişimin kolaylaştırılmasını sağlar.
				return c.Blogs.Include(x => x.Category).ToList();
			}
		}
	}
}
