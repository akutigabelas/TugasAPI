using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp2.Context;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class UserController : Controller
    {
        MyContextt myContextt;

        public UserController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        } 
        public IActionResult Index()
        {
            var data = myContextt.Users.ToList();
            return View(data);
        }

        public IActionResult Details(int id) {

            var data = myContextt.Users.Find(id);
            return View();
        } 

        public IActionResult Create()
        {
            var dd = new UserVM();
            dd.Employees = myContextt.Employees.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            }).ToList();

            dd.Roles = myContextt.Roles.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Nama
            }).ToList();

            return View(dd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            myContextt.Users.Add(user);
            var result = myContextt.SaveChanges();
            if(result > 0)
                return RedirectToAction("Index", "User");
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = myContextt.Users.Find(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            var data = myContextt.Users.Find(id);
            if(data != null)
            {
                data.Password = user.Password;
                var result = myContextt.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "User");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var data = myContextt.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(User user)
        {
            myContextt.Users.Remove(user);
            var result = myContextt.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "User");
                    return View();
        }

    }
}
