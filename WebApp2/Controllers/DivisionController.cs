using Microsoft.AspNetCore.Mvc;
using WebApp2.Context;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class DivisionController : Controller
    {
        MyContextt myContextt;

        public DivisionController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }

        public IActionResult Index()
        {
            var data = myContextt.Divisions.ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = myContextt.Divisions.Find(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Division division)
        {
            myContextt.Divisions.Add(division);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }

        // UPDATE - GET POST
        public IActionResult Edit(int id)
        {
            var data = myContextt.Divisions.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Division division)
        {
            var data = myContextt.Divisions.Find(id);
            if (data != null)
            {
                data.Nama = division.Nama;
                myContextt.Entry(data).State = EntityState.Modified;
                var result = myContextt.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Division");
            }
            return View();
        }
        // DELETE - GET POST
        public IActionResult Delete(int id)
        {
            var data = myContextt.Divisions.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Division division)
        {
            myContextt.Divisions.Remove(division);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }
    }
}
