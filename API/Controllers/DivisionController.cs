using API.Base;
using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<DivisionRepositories, Division>
    {
        DivisionRepositories repositories;

        public DivisionController(DivisionRepositories _repositories) : base(_repositories)
        {
            this.repositories = _repositories;
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var data = repositories.Get();
        //    return Ok(new { message = "data has been retrieved", StatusCode = 200, data = data });

        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var data = repositories.GetById(id);
        //    return Ok(new { message = "data has been retrieved", StatusCode = 200, data = data });

        //}
        //[HttpPost]
        //public IActionResult Create(Division division)
        //{
        //    var data = repositories.Create(division);
        //    return Ok(new { message = "data has been Created", StatusCode = 200, data = data });

        //}
        //[HttpPut]
        //public IActionResult Update(Division division)
        //{
        //    var data = repositories.Update(division);
        //    return Ok(new {message = "data has been update", statusCode = 200, data = data });
        //}
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var result = repositories.Delete(id);
        //        if (result == 0)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "gagal dihapus"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "berhasil dihapus"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}

    }
}
