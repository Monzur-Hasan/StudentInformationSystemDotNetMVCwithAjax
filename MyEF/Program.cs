using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.BLL.BLL;

namespace MyEF
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager _studentManager = new StudentManager();

            //DepartmentManager _departmentManager = new DepartmentManager();


            //Console.WriteLine("\t\tDepartment");
            //foreach (var department in _departmentManager.GetAllDepartments())
            //{
            //    Console.WriteLine("\nDepartment Name:\t" + department.Name + "\n\t\t\t\tStudents");
            //    if (department.Students != null && department.Students.Any())
            //    {

            //        foreach (var student in department.Students)
            //        {
            //            Console.WriteLine("Student RollNo:\t" + student.RollNo + "\tName:\t" + student.Name + "\tAge:\t" + student.Age);
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("\t\tNo Student Found!!!");
            //    }
            //}


            //Department department = new Department()
            //{
            //    Name = "ENG",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //                RollNo = "009",
            //                Name =  "Fajle",
            //                Address = "Mirpur",
            //                Age = 40
            //        },
            //        new Student()
            //        {
            //            RollNo = "010",
            //            Name =  "Arafat",
            //            Address = "Mirpur",
            //            Age = 16
            //        }
            //    }
            //};

            try
            {
                Student student = new Student()
                {

                    RollNo = "004",
                    Name = "Sohag",
                    Email = "sohag@gmail.com",
                    PhoneNo = "01891840830",
                    Address = "Mirpur-2",
                    Age = 25
                };

                //if (_studentManager.Add(student))
                //{
                //    Console.WriteLine("Saved Successfully");
                //}

                //else
                //{
                //    Console.WriteLine("Not Saved!");
                //}

                //Console.Write("Enter Delete Id : ");
                //int id = Convert.ToInt32(Console.ReadLine());

                //if (_studentManager.Delete(id))
                //{
                //    Console.WriteLine("Deleted");
                //}

                //else
                //{
                //    Console.WriteLine("Not Deleted!");
                //}


                //Console.Write("Enter Delete Id : ");
                //int id = Convert.ToInt32(Console.ReadLine());

                //student.Id = id;
                //student.RollNo = "001";
                //student.Name = "Monzur Hasan";
                //student.Email = "monzur@gmail.com";
                //student.PhoneNo = "01518408308";
                //student.Address = "Rupnagar R/A";
                //student.Age = 25;

                //if (_studentManager.Update(student))
                //{
                //    Console.WriteLine("Updated Successfully");
                //}

                //else
                //{
                //    Console.WriteLine("Not Updated");
                //}

               

               // var students = _studentManager.GetAllStudents();


                Console.Write("Enter Search Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                var aStudent = _studentManager.GetById(id);
            }

            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


            Console.WriteLine("-----------------------------------------------------------");
            int i = 1;
            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in _studentManager.GetAllStudents())
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.WriteLine("----------------------------LINQ-----------------------");
            i = 1;


            var students = _studentManager.GetAllStudents();
            //SELECT * FROM Student WHERE Age> 20 AND Age <30
            var result = from s in students
                         where s.Age > 20 && s.Age < 30
                         select s;

            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in result)
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }
            Console.ReadKey();
        }
    }
}
