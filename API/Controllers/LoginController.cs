using API.Context;
using API.Handlers;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        MyContextt myContextt;

        public LoginController(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {

            var data = myContextt.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));

            var validasiPass = Hashing.ValidatePassword(password, data.Password);
            if (data != null && validasiPass)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Berhasil Login"
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Email atau Password Salah"
                });
            }
            
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
            var cekemail = myContextt.Employees.SingleOrDefault(x => x.Email.Equals(email));
            if (cekemail == null)
            {
                var result = myContextt.SaveChanges();
                if (result > 0)
                {
                    var id = myContextt.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 1
                    };
                    myContextt.Users.Add(user);
                    var resultUser = myContextt.SaveChanges();
                    if (resultUser > 0)
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Akun berhasil"

                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            StatusCode = 200,
                            Message = "Akun gagal dibuat"
                        });
                    }
                }
            }
        }

        //[HttpPost]
        //public IActionResult GantiPass(string fullname, string passlama, string passbaru)
        //{
        //    var data = myContextt.Users
        //         .Include(x => x.Employee)
        //         .SingleOrDefault(x => x.Employee.FullName.Equals(fullname));

        //    var validasiPass = Hashing.ValidatePassword(passlama, data.Password);
        //    if (data != null)
        //    {
        //        data.Password = Hashing.HashPassword(passbaru);

        //        myContextt.Entry(data).State = EntityState.Modified;
        //        var resultUser = myContextt.SaveChanges();
        //        if (resultUser > 0)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //    }
        //    return View();
        //}

        //public IActionResult LupaPass()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult LupaPass(string passlama, string fullname, string passbaru)
        //{
        //    var data = myContextt.Users
        //          .Include(x => x.Employee)
        //          .SingleOrDefault(x => x.Employee.FullName.Equals(fullname));
        //    var validasiPass = Hashing.ValidatePassword(passlama, data.Password);
        //    if (data != null)
        //    {
        //        data.Password = Hashing.HashPassword(passbaru);

        //        myContextt.Entry(data).State = EntityState.Modified;
        //        var resultUser = myContextt.SaveChanges();
        //        if (resultUser > 0)
        //        {
        //            return RedirectToAction("Login", "Login");
        //        }
        //    }
        //    return View();
        //}

    }
}
