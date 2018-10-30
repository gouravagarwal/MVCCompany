using CompanyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyDemo.Controllers
{
    [RoutePrefix("Department")]
    public class DepartmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Department
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        [HttpPost]
        [Route("CreateDept")]
        public JsonResult CreateDept(Department dept)
        {
            if (dept != null && ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();

                return Json("true");
            }
            else
                return Json("false");
        }

        [HttpGet]
        [Route("GetDepartments")]
        public JsonResult GetDepartments()
        {
            return Json(new { depts = db.Departments.Select(x => new { Id = x.Id , DeptName = x.DeptName}).ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("CreateEmp")]
        public JsonResult CreateEmp(Employee emp)
        {
            if (emp != null && ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                return Json("true");
            }
            else
                return Json("false");

        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public JsonResult GetEmployees(int? id)
        {

            var employees = db.Employees.Where(x => x.DepartmentId == id).ToList();

            return Json(employees);
        }


    }
}