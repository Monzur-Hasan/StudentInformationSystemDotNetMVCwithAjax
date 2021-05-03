using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.DatabaseContext.DatabaseContext;

namespace WebApp.Repository.Repository
{
    public class ResultRepository
    {
        StudentDbContext dbContext = new StudentDbContext();
        public bool Add(Result result)
        {
            dbContext.Results.Add(result);
            //dbContext.SaveChanges();
            return dbContext.SaveChanges() > 0;
        }
    }
}
