using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentRepositories repo;

        public DepartmentController(DepartmentRepositories repositories)
        {
            repo = repositories;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = repo.Get();
                if(data == null) { 
                return Ok(
                    new
                    {
                        StatusCode = 200,
                        Message = "data masih kosong"
                    } );
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "data tidak kosong"
                    });
                }
         }
            catch (Exception ex) {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = repo.GetById(id);
                if (data == null)
                {
                    return Ok(new { 
                        StatusCode = 200,
                        Message = "data tidak ada" });
                }
                else
                {

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "data ditemukan"
                });
                }
            }
            catch(Exception ex) {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
                    }
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
            var result = repo.Create(department);
            if (result == 0)
            {
                return Ok(new {
                    StatusCode = 200,
                    Message = "data tidak ditemukan" });
                }
                else
                {
            return Ok(new { 
                StatusCode = 200,
                Message = "data dah kesimpen ya" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpPut]
        public IActionResult Update(Department department)
        {
            try
            {
            var result = repo.Update(department);
            if (result == 0)
            {
                return Ok(new { 
                    StatusCode = 200,
                    Message = "data gagal diupdate" });
                }
                else
                {
            return Ok(new { 
                StatusCode = 200,
                Message = "data telah diupdate" });
                }
            }
            catch(Exception ex) {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
            var result = repo.Delete(id);
            if (result == 0)
            {
                return Ok(new { 
                    StatusCode = 200,
                    Message = "gagal dihapus" });
            }
                else
                {
            return Ok(new { 
                StatusCode = 200,
                Message = "berhasil dihapus" });
                }
            } catch(Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
