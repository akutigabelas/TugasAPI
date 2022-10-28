using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Context;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class RoleController : Controller
    {
        MyContextt myContextt;

        public RoleController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }

        public IActionResult Index()
        {
            var data = myContextt.Roles.ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = myContextt.Roles.Find(id);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Role role)
        {
            myContextt.Roles.Add(role);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Role");
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = myContextt.Roles.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Role role)
        {
            var data = myContextt.Roles.Find(id);
            if(data != null)
            {
                data.Nama = role.Nama;
                myContextt.Entry(data).State = EntityState.Modified;
                var result = myContextt.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Role");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = myContextt.Roles.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Role role)
        {
            myContextt.Roles.Remove(role);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Role");
             return View();
        }
    }
}
