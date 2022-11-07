using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration configuration;
        private LoginRepositories repo;
        public LoginController(LoginRepositories loginRepo, IConfiguration config)
        {
           configuration = config;
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
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", data[0].ToString()),
                        new Claim("Email", data[2].ToString()),
                        new Claim("Fullname", data[1].ToString()),
                        new Claim("Role", data[3].ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            catch { 
                {
                    return BadRequest();
                }
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
