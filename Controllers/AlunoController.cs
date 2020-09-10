using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Data;
using escola.Models;
using Microsoft.AspNetCore.Authorization;
using System;

namespace escola.Controllers
{
    [Route("v1/Alunos")]
    public class ProductController : Controller
    {

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Aluno>> GetById([FromServices] DataContext context, int id)
        {
            var alunos = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return alunos;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Aluno>>> Get([FromServices] DataContext context)
        {
            var alunos = await context.Alunos.Include(x => x.Turmas).AsNoTracking().ToListAsync();
            //nao crie proxy dos objetos com o AsNoTracking,jogar dados direto na tela
            //tolist sempre no fim, depois do where
            return alunos;
        }
        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Aluno>> Post(
            [FromServices] DataContext context,
            [FromBody] Aluno model)
        {
            if (ModelState.IsValid)
            {
                context.Alunos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Aluno>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var category = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Aluno nao encontrado" });

            try
            {
                context.Alunos.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Aluno" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Aluno>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody] Aluno model)
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Aluno nao não encontrado" });

            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Aluno>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a o Aluno" });

            }
        }

    }
}