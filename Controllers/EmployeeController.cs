using Example_Project.Models;
using Example_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employee()
        {

            EmployeeRepository dbhandle = new EmployeeRepository();
            ModelState.Clear();
            return View(dbhandle.GetList());
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddEmployee(Employee smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository sdb = new EmployeeRepository();
                    if (sdb.Employee(smodel))
                    {
                        ViewBag.Message = "Employee Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeRepository sdb = new EmployeeRepository();
            return View(sdb.GetList().Find(smodel => smodel.EmployeeId == id));
        }


        [HttpPost]
        public ActionResult Edit(int id, Employee smodel)
        {
            try
            {
                EmployeeRepository sdb = new EmployeeRepository();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeRepository sdb = new EmployeeRepository();
                if (sdb.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee Deleted Successfully";
                }
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }

    }
}