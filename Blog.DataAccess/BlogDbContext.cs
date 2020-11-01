
using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess
{
    public class BlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //You can change your mssql information
            optionsBuilder.UseSqlServer("Server=DESKTOP-0Q2H04V;Database=BlogDb;uid=sa;pwd=1234");

        }

        public DbSet<Post> Posts { get; set; }
    }
}
