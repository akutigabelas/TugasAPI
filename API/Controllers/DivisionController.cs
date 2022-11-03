using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly DivisionRepositories repositories;

        public DivisionController(DivisionRepositories _repositories)
        {
            repositories = _repositories;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = repositories.Get();
                if (data == null)
                {
                    return Ok(
                        new
                        {
                            StatusCode = 200,
                            Message = "data masih kosong"
                        });
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
            catch (Exception ex)
            {
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
                var data = repositories.GetById(id);
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
                    Message = "data tidak kosong"
                });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        
        }
        [HttpPost]
        public IActionResult Create(Division division)
        {
            try
            {
                var result = repositories.Create(division);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "data tidak ditemukan"
                    });
                }
                else
                {
                return Ok(new { 
                    StatusCode = 200,
                    Message = "data dah kesimpen ya" });

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
        [HttpPut]
        public IActionResult Update(Division division)
        {
            try
            {
            var result = repositories.Update(division);
            if(result == 0)
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
            catch(Exception ex)
            {
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
            var result = repositories.Delete(id);
            if(result == 0)
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
            }
            catch(Exception ex) {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
                    }
        }

    }
}
