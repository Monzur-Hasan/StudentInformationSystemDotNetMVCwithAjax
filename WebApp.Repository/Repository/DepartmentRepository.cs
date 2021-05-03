using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace WebApp.Repository.Repository
{
    public class DepartmentRepository
    {
        StudentDbContext _dbContext = new StudentDbContext();

        public bool Add(Department department)
        {
            _dbContext.Departments.Add(department);

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Department aDepartment = _dbContext.Departments.FirstOrDefault(c => c.Id == id);
           
            _dbContext.Departments.Remove(aDepartment);

            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Department department)
        {
            Department aDepartment = _dbContext.Departments.FirstOrDefault(c => c.Id == department.Id);
            
            if(aDepartment != null)
            {
                
                aDepartment.Name = department.Name;
                
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Department> GetAllDepartments()
        {
            // return _dbContext.Departments.ToList();
            // return _dbContext.Departments.Include(c => c.Students).ToList(); //Eagar Loading

            var departments = _dbContext.Departments.ToList();

            foreach (var department in departments)
            {
                _dbContext.Entry(department)
                   .Collection(c => c.Students)
                   .Query()
                   .Where(c => c.Age > 20)
                   .Where(c => c.Name.Contains("l"))
                   .Load();
            }

            return departments;
        }

        public Department GetById(int id)
        {

            return _dbContext.Departments.FirstOrDefault((c => c.Id == id));
        }
    }
}
