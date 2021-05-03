using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.Repository.Repository;


namespace WebApp.BLL.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();

        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public bool Delete(Student student)
        {
            return _studentRepository.Delete(student);
        }

        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
