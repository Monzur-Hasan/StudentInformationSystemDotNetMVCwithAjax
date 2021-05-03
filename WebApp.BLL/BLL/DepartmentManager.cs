using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Repository;
using WebApp.Model.Model;

namespace WebApp.BLL.BLL
{
    public class DepartmentManager
    {

        DepartmentRepository _departmentRepository = new DepartmentRepository();
        public bool Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public bool Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }
        public bool Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }
        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
