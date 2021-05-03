using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Model.Model;
using System.ComponentModel.DataAnnotations;  // [Required]
using System.Web.Mvc;

namespace WebApp.Models
{
    public class StudentViewModel  // View related model or View Model
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Roll No can not be Empty!")]
        //[MaxLength(4, ErrorMessage ="Maximum Length is 4")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage ="Roll No must be 3 digit")]
        [Display(Name = "Roll No")]
        public string RollNo { get; set; }

        [Display(Name = "Student Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage ="Please Select Department Name")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
       

        public List<Student> Students { get; set; }
        public List<SelectListItem> DepartmentSelectListItems { get; set; } //for dropDownList-> SelectListItem select kore

    }

}