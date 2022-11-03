using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    public class ErrorPageController : Controller
    {
       public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult UnAuthorized()
        {
            return View();
        }

        
    }
}
