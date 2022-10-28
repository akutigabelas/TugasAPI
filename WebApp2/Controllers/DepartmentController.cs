using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Context;
using WebApp2.Models;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp2.Controllers
{
    public class DepartmentController : Controller
    {
        MyContextt myContextt;

        public DepartmentController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }


        // GET: DepartmentController
        public IActionResult Index()
        {
            var data = myContextt.Departments.ToList();
            return View(data);
        }

        // GET: DepartmentController/Details/5
        public IActionResult Details(int id)
        {
            var data = myContextt.Departments.Find(id);
            return View(data);
        }

        // GET: DepartmentController/Create
        public IActionResult Create()
        {
            var dd = new DepartmentVM();
            dd.Divisions = myContextt.Divisions.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Id.ToString()
            }).ToList();
            return View(dd);
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            myContextt.Departments.Add(department);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }

        // GET: DepartmentController/Edit/5
        public IActionResult Edit(int id)
        {
            var data = myContextt.Departments.Find(id);
            return View(data);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            var data = myContextt.Departments.Find(id);
            if (data != null)
            {
                data.Nama = department.Nama;
                myContextt.Entry(data).State = EntityState.Modified;
                var result = myContextt.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Department");
            }
            return View();
        }

        // GET: DepartmentController/Delete/5
        public IActionResult Delete(int id)
        {
            var data = myContextt.Departments.Find(id);
            return View(data);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            myContextt.Departments.Remove(department);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }
    }
}
