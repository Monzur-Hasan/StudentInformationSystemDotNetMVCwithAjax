using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApp.Model.Model;
using WebApp.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace WebApp.Repository.Repository
{
    public class StudentRepository
    {
        StudentDbContext _dbContext = new StudentDbContext();
        public bool Add(Student student)
        {
            _dbContext.Students.Add(student);

            return _dbContext.SaveChanges() > 0;   //Execute > 0
        }

        public bool Delete(Student student)
        {
            Student aStudent = _dbContext.Students.FirstOrDefault(c => c.Id == student.Id); //FirstOrDefault-> retrieve data from database

            _dbContext.Students.Remove(aStudent); //Remove->Model object entity ney

            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Student student)
        {
            //Student aStudent = _dbContext.Students.FirstOrDefault(c => c.Id == student.Id); //FirstOrDefault-> retrieve data from database

            //if (aStudent != null)
            //{
            //    aStudent.RollNo = student.RollNo;
            //    aStudent.Name = student.Name;
            //    aStudent.Email = student.Email;
            //    aStudent.PhoneNo = student.PhoneNo;
            //    aStudent.Address = student.Address;
            //    aStudent.Age = student.Age;
            //    aStudent.DepartmentId = student.DepartmentId;

            _dbContext.Entry(student).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
       
        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.Include(c => c.Department).ToList();
        }

        public Student GetById(int id)
        {
            return _dbContext.Students.FirstOrDefault(c => c.Id == id);            
        }
    }
}
