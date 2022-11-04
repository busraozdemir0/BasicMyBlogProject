using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projem.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;database=blogdb;password=sonel.1234;port=3306");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Login> Logins { get; set; }
       

    }
}
