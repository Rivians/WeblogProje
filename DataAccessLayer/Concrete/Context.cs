﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-MO8Q2VS\\SQLEXPRESS; database=WeblogDb; integrated security=true; TrustServerCertificate = True;");
		}

		// DESKTOP-MO8Q2VS\\SQLEXPRESS  >>> pc serveri 
		// DESKTOP-OHHVBJO\\SQLEXPRESS  >>> leptop serveri

		public DbSet<About> Abouts {  get; set; } 
		public DbSet<Blog> Blogs {  get; set; } 
		public DbSet<Category> Categories {  get; set; } 
		public DbSet<Comment> Comments {  get; set; } 
		public DbSet<Contact> Contacts {  get; set; } 
		public DbSet<Writer> Writers {  get; set; }
        public DbSet<NewsLetter> NewsLetters{ get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
