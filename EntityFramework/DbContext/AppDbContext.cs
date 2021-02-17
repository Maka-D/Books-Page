using Microsoft.EntityFrameworkCore;
using Project_2_2.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {

        }

        public DbSet<BooksInfo> BooksDetails { get; set; }
        public DbSet<AuthorsInfo> AuthorsDetails { get; set; }
    }
}
