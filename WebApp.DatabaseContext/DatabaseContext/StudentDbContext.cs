using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApp.Model.Model;

namespace WebApp.DatabaseContext.DatabaseContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
            Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        }

        public DbSet<Student> Students { set; get; } //Create Table in Database
        public DbSet<Department> Departments { set; get; }    
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultDetails> ResultDetailses { get; set; }
    }
}
