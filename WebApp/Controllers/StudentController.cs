using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model.Model;
using WebApp.BLL.BLL;
using WebApp.Models;
using AutoMapper;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();

        //error-> 'Add' on controller type 'StudentController' is ambiguous between the following action methods
        //[HttpGet]-> Controller method overloading chine na so runtime e error dey, bt se HttpGet, Post chine,
        //Initially HttpGet method e jabe run korar por, thn value deyar por submit [HttpPost] method e jabe, get post na dile controller confusion e pore tokhn error dey

        [HttpGet]
        public ActionResult Add()
        {
            //Student student = new Student();
            //Model alltime paramter with value nibe so View() blank dile error dibe. So sutdent obj dite dibe
            //return View(student);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAllStudents(); //Load data from Database
            //DropDownListFor
            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                         .Select(c => new SelectListItem //Select Object from SelectListItem, if 1 ta dept thake obj create kora lagto na
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
                                                         }).ToList();
            return View(studentViewModel);
        }


        //public string Add(string rollNo, string name, string address, int? age, int? departmentId)
        //public ActionResult Add(Student student, string name)

        [HttpPost]
        //public ActionResult Add(Student student)
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student(); //property to property pass data viewModel to entity model
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Email = studentViewModel.Email;
            //student.PhoneNo = studentViewModel.PhoneNo;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;

            //Object to Object pass Data
            //*Install AutoMapper -> go to Package Manager Console then give cmd=> Install-Package AutoMapper -Version 8.0.0 --configure file Global.asax

            if (ModelState.IsValid)  //catch Model Validation
            {
                Student student = Mapper.Map<Student>(studentViewModel);
                // Mapper.Map<TDestination or Output>(source);
                if (_studentManager.Add(student))
                {
                    message = "Saved Successfully";
                }

                else
                {
                    message = "Not Saved !";
                }
            }

            else
            {
                message = "Validation Model State Failed!";
            }

            //// ViewBag->dynamic type, local variable hisebe kaj kore. er scope just view er vitore
            ////Controller thk msg or data niye view te pathaia dey
            
            ViewBag.Message = message;  

            studentViewModel.Students = _studentManager.GetAllStudents();//Update studentViewModel-> List<Student> - view null obj ney na so add korar por list load dite hbe

            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                        .Select(c => new SelectListItem //Select Object from SelectListItem, if 1 ta dept thake obj create kora lagto na
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();

            return View(studentViewModel); //catch data from Model and send to View()
        }


        [HttpGet]
        public ActionResult Search()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAllStudents();

            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                         .Select(c => new SelectListItem
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
                                                         }).ToList();
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Search(StudentViewModel studentViewModel)
        {
            var students = _studentManager.GetAllStudents();

            if (studentViewModel.RollNo != null)
            {
                students = students.Where(c => c.RollNo.Contains(studentViewModel.RollNo)).ToList();
            }

            if (studentViewModel.Name != null)
            {
                students = students.Where(c => c.Name.ToLower().Contains(studentViewModel.Name.ToLower())).ToList();
            }

            studentViewModel.Students = students;

            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                          .Select(c => new SelectListItem
                                                          {
                                                              Value = c.Id.ToString(),
                                                              Text = c.Name
                                                          }).ToList();
            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //StudentViewModel studentViewModel = new StudentViewModel();

            var student = _studentManager.GetById(id);

            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            studentViewModel.Students = _studentManager.GetAllStudents();

            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                       .Select(c => new SelectListItem
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
            return View(studentViewModel);
        }


        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Update(student))
                {
                    message = "Updated Successfully";
                }

                else
                {
                    message = "Not Updated !";
                }
            }

            else
            {
                message = "ModelState Failed!!!";
            }

            ViewBag.Message = message;

            studentViewModel.Students = _studentManager.GetAllStudents();

            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                          .Select(c => new SelectListItem
                                                          {
                                                              Value = c.Id.ToString(),
                                                              Text = c.Name
                                                          }).ToList();

            return View(studentViewModel);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = _studentManager.GetById(id);
            var studentViewModel = Mapper.Map<StudentViewModel>(student);
            studentViewModel.Students = _studentManager.GetAllStudents();
            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                            .Select(c => new SelectListItem()
                                            {
                                                Value = c.Id.ToString(), Text = c.Name
                                            }).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentViewModel studentViewModel)
        {
                       
            
            if (ModelState.IsValid)
            {
                var student = Mapper.Map<Student>(studentViewModel);
                if (_studentManager.Delete(student))
                {
                    ViewBag.Message = "Deleted Succesfully";
                }

                else
                {
                    ViewBag.Message = "Not Deleted !";
                }

            }
            else
            {
                ViewBag.Message = "Model State Failed !";
            }

            studentViewModel.Students = _studentManager.GetAllStudents();
            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                         .Select(c => new SelectListItem
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
                                                         }).ToList();

            return View(studentViewModel);
        }

        public ActionResult StudentsDetails()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
          
            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAllDepartments()
                                                         .Select(c => new SelectListItem
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
                                                         }).ToList();

            ViewBag.Department = studentViewModel.DepartmentSelectListItems;//send DepartmentSelectListItems to name: Department DropDown must be same name
            return View();
        }

        //Cascade DropDown
        //public string GetStudentByDepartmentId(int departmentId)
        public JsonResult GetStudentByDepartmentId(int departmentId) //Ajax-> Json niye kaj kore
        {
            //filtering -> specific deptId base Data
            var studentList = _studentManager.GetAllStudents().Where(c => c.DepartmentId == departmentId).ToList();

            var students = from s in studentList select (new { s.Id, s.Name });//filtering -> specific send column
            
            return Json(students, JsonRequestBehavior.AllowGet); //JsonResult-> Json Obj return kore
            //run time error -> JsonRequestBehavior.AllowGet na dile errror dibe, karon Json JsonRequestBehavior.AllowGet allow kore sudhu Get na
        }


        //Unique Test
        public JsonResult IsStudentExist(string rollNo)
        {
            bool isExists = false;
            var studentList = _studentManager.GetAllStudents().Where(c => c.RollNo == rollNo).ToList();

            if(studentList.Count > 0)
            {
                isExists = true;
            }
            return Json(isExists, JsonRequestBehavior.AllowGet);
        }


        //StudentDetails
        public ActionResult GetStudentById(int id)
        {
            //var student = _studentManager.GetById(id);
            //StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAllStudents().Where(c => c.Id == id).ToList();
            return PartialView("Student/_StudentDetails", studentViewModel);
        }
    }
}

//Validation Unobtrusive for Scripts -> install latest version in manage nuget package
