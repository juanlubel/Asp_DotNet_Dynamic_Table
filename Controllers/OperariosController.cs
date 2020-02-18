using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiASPLinux.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiASPLinux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperariosController : ControllerBase
    {
        private readonly ProduccionContext context;

        public OperariosController(ProduccionContext context)
        {
            this.context = context;
        }
        // GET: api/Operarios
        [HttpGet]
        public IEnumerable<Operario> Get()
        {
            return context.Operarios.ToList();
        }

        // GET: api/Operarios/5
        [HttpGet("{id}", Name = "GetOperario")]
        public IActionResult Get(int id)
        {
            var operario = context.Operarios.FirstOrDefault(operario => operario.Id == id);

            if (operario == null)
            {
                return NotFound();
            }
            return Ok(operario);
        }

        // POST: api/Operarios
        [HttpPost]
        public IActionResult Post([FromBody] Operario operario)
        {
            if (ModelState.IsValid) {
                context.Operarios.Add(operario);
                context.SaveChanges();
                return new CreatedAtRouteResult("GetOperario", new {id = operario.Id}, operario);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Operarios/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Operario operario)
        {
            if (operario.Id != id) 
            {
                return BadRequest();
            }
            context.Entry(operario).State = EntityState.Modified;
            context.SaveChanges();
            return new CreatedAtRouteResult("GetOperario", new {id = operario.Id}, operario);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var operario = context.Operarios.FirstOrDefault(operario => operario.Id == id);

            if (operario == null)
            {
                return NotFound();
            }

            context.Operarios.Remove(operario);
            context.SaveChanges();
            return Ok(operario);
        }
    }
}
