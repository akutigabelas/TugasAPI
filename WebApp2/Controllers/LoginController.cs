using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp2.Context;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class LoginController : Controller
    {
        MyContextt myContextt;

        public LoginController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }
      public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = myContextt.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email) && x.Password.Equals(password));
            if(data != null)
            {
                LoginVM loginVM = new LoginVM()
              {
                FullName = data.Employee.FullName,
                Email = data.Employee.Email,
                Nama = data.Role.Nama
            };
                return RedirectToAction("Index", "Home", loginVM);
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, string birthDate, string password)
        {
            Employee employee = new Employee()
            {
                FullName = fullName,
                Email = email,
                BirthDate = birthDate
            };
            myContextt.Employees.Add(employee);
            var result = myContextt.SaveChanges();
            if(result > 0)
            {
                var id = myContextt.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = password,
                    RoleId = 1
                };
                myContextt.Users.Add(user);
                var resultUser = myContextt.SaveChanges();
                if (resultUser > 0)
                    return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public IActionResult GantiPass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GantiPass(string fullname, string passlama, string passbaru)
        {
            var data = myContextt.Users
                 .Include(x => x.Employee)
                 .SingleOrDefault(x => x.Employee.FullName.Equals(fullname) && x.Password.Equals(passlama));
            if (data != null)
            {
              data.Password = passbaru;

                myContextt.Entry(data).State = EntityState.Modified;
                var resultUser = myContextt.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }

        public IActionResult LupaPass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LupaPass(string passlama, string fullname, string passbaru)
        {
                var data = myContextt.Users
                      .Include(x => x.Employee)
                      .SingleOrDefault(x => x.Employee.FullName.Equals(fullname) && x.Password.Equals(passlama));
            if (data != null)
            {
                data.Password = passbaru;
    
                myContextt.Entry(data).State = EntityState.Modified;
                var resultUser = myContextt.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }

    }
  }

