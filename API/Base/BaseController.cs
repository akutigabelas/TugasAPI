using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity, int>
        where Entity : class
    {
        Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var data = repository.Get();
            try
            {
                var data = repository.Get();
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
                        Message = "Data has been retrieved",
                        Data = data
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
            //return Ok(new { message = "Data has been retrieved", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var data = repository.GetById(id);
            try
            {
                var data = repository.GetById(id);
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
                        Message = "data has been retrieved",
                        Data = data
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
            //return Ok(new { message = "data has been retrieved", statusCode = 200, data = data });
        }

        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            //var data = repository.Create(entity);
            try
            {
                var data = repository.Create(entity);
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
                        Message = "data tidak kosong",
                        Data = data
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
            //return Ok(new { message = "data has been created", StatusCode = 200, data = data });
        }

        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            //var data = repository.Update(entity);
            try
            {
                var data = repository.Update(entity);
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
                        Message = "data has been update",
                        Data = data
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
            //return Ok(new { message = "data has been updated", StatusCode = 200, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //var data = repository.Delete(id);
            try
            {
                var data = repository.Delete(id);
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
                        Message = "data tidak kosong",
                        Data = data
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
            //return Ok(new { message = "data has been deleted", StatusCode = 200, data = data });
        }



            //          try
            //            {
            //                var data = repo.Get();
            //                if (data == null)
            //                {
            //                    return Ok(
            //                        new
            //                        {
            //                            StatusCode = 200,
            //                            Message = "data masih kosong"
                           
            //                        });
            //                }
            //                else
            //{
            //    return Ok(new
            //    {
            //        Status = 200,
            //        Message = "data tidak kosong",
            //        Data = data
            //    });
            //}
            //            }
            //            catch (Exception ex)
            //{
            //    return BadRequest(new
            //    {
            //        StatusCode = 400,
            //        Message = ex.Message
            //    });
            //}
    }
}
