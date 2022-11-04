using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginRepositories repo;
        public LoginController(LoginRepositories loginRepo)
        {
           repo = loginRepo;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            try
            {

            var data = repo.Login(email, password);
            
            if (data != null)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Berhasil Login",
                    Data = new
                    {
                       Email = data[2],
                       FullName = data[1],
                       Role = data[3]
                    }
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = 200,
                    Message = "Email atau Password Salah"
                });
                }

            } 
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Email atau Password Salah"
                });
            }

        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(string fullName, string email, string birthDate, string password)
        {
            try
            {
                var data = repo.Register(fullName, email, birthDate, password);
                if (data == 1)
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
            catch (Exception ex)
             {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Akun gagal dibuat"
                });
            }
                return Ok();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(string fullname, string passlama, string passbaru)
        {
            try
            {

           var data = repo.ChangePassword(fullname, passlama, passbaru);
            if(data == 1)
            {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Password berhasil diganti berhasil"

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 200,
                        Message = "Password gagal diganti"
                    });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Gagal Ganti Password"
                });
            }
            return Ok();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string fullname, string passlama, string passbaru)
        {
            try
            {
                var data = repo.ForgotPassword(fullname, passlama, passbaru);
                if (data == 1)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Password berhasil diganti berhasil"

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 200,
                        Message = "Password gagal diganti"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Gagal Ganti Password"
                });
            }
            return Ok();
        }
    }
}
