using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Context;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class EmployeeController : Controller
    {
        MyContextt myContextt;

        public EmployeeController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }

        public IActionResult Index()
        {
            var data = myContextt.Employees.ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = myContextt.Employees.Find(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            myContextt.Employees.Add(employee);
            var result = myContextt.SaveChanges();
            if(result > 0)
                return RedirectToAction("Index", "Employee");
            return View();
        }

        public IActionResult Edit(int id, Employee employee)
        {
            var data = myContextt.Employees.Find(id);
            if(data != null)
            {
                data.FullName = employee.FullName;
                data.Email = employee.Email;
                data.BirthDate = employee.BirthDate;
                myContextt.Entry(data).State = EntityState.Modified;
                var result = myContextt.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = myContextt.Employees.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            myContextt.Employees.Remove(employee);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Employee");
            return View();
        }
    }
}
