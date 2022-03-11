using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Models;

namespace Web.API.Data
{
    public class MyDbContext:DbContext
    {

        //connectionString
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=YourDatabase;Database=APIProject-Test;Trusted_Connection=True;");
        }
        //DbSet
        public DbSet<Categorys> Categorys { get; set; }
    }
}
