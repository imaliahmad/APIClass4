using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Data;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private MyDbContext context;
        public CategorysController(MyDbContext _context)
        {
            context = _context;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await context.Categorys.ToListAsync();
                return Ok(new JsonResponse() { IsSuccess = true, Data = list });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = ex.Message });
            }
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var obj = await context.Categorys.FindAsync(id);
                if (obj == null)
                {
                    return NotFound(new JsonResponse() { IsSuccess = false, Message = "Record not found." });
                }

                return Ok(new JsonResponse() { IsSuccess = true, Data = obj });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = ex.Message});
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Categorys model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Categorys.Add(model);
                    await context.SaveChangesAsync();
                    //return CreatedAtAction("getById", new { id = model.CategoryId }, model);

                    return Ok(new JsonResponse() { IsSuccess = true, ErrorCode = 201, Data = model }) ;
                }
                else
                {
                    return BadRequest(ModelState.Values);
                }
                
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Categorys model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Categorys.Update(model);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState.Values);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var obj = await context.Categorys.FindAsync(id);
                if (obj == null)
                {
                    return NotFound(new JsonResponse() { IsSuccess = false, Message = "Record not found." });
                }

                context.Categorys.Remove(obj);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = ex.Message });
            }
        }

    }
}
