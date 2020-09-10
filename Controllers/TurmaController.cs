using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Data;
using escola.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace escola.Controllers
{
    [ApiController]
    [Route("v1/Turmas")]
    public class CategoryController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]

        public async Task<ActionResult<List<Turma>>> Get([FromServices] DataContext context)
        {
            var Turmas = await context.Turmas.AsNoTracking().ToListAsync();
            return Turmas;
        }


        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Turma>> GetById([FromServices] DataContext context, int id)
        {
            var turmas = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return turmas;
        }



        [HttpPost]
        [Route("")]
        // [Authorize(Roles = "employee")]
        [AllowAnonymous]
        public async Task<ActionResult<Turma>> Post(
            [FromServices] DataContext context,
            [FromBody] Turma model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Turmas.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a turma" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Turma>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var category = await context.Turmas.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Turma nao encontrada" });

            try
            {
                context.Turmas.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a turma" });

            }
        }


    }
}