using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example_Project.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name:")]
        [Required(ErrorMessage= "Please Enter Employee Name")]
        public string EmployeeName { get; set; }

        public string Designation { get; set; }

        [Display(Name = "Salary:")]
        [Required(ErrorMessage = "Salary is required")]
        [Range(3000, 10000000, ErrorMessage = "Salary must be between 3000 and 10000000")]
        public decimal? Salary { get; set; }
        [Display(Name = "Email Address:")]
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
       
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
       
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone Number Required!")]

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //           ErrorMessage = "Entered phone format is not valid.")]
        public string Mobile { get; set; }
        public string Qualification { get; set; }
        public string Manager { get; set; }




    }
}