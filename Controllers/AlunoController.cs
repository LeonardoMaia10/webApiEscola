using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Data;
using escola.Models;
using Microsoft.AspNetCore.Authorization;

namespace escola.Controllers
{
    [Route("v1/Alunos")]
    public class ProductController : Controller
    {
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
            [FromBody]Aluno model)
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
    }
}