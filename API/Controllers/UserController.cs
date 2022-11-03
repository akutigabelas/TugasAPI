﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using API.Context;
using API.Models;
using API.Repositories.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepositories repo;
        public UserController(UserRepositories repositories)
        {
            repo = repositories;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = repo.Get();
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
                var data = repo.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "data tidak ada"
                    });
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
        public IActionResult Create(User user)
        {
            try
            {
                var result = repo.Create(user);
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
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "data dah kesimpen ya"
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
        [HttpPut]
        public IActionResult Update(User user)
        {
            try
            {
                var result = repo.Update(user);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "data gagal diupdate"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "data telah diupdate"
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = repo.Delete(id);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "gagal dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "berhasil dihapus"
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
    }
}
