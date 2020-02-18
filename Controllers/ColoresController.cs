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
    public class ColoresController : ControllerBase
    {
        private readonly ProduccionContext context;

        public ColoresController(ProduccionContext context)
        {
            this.context = context;
        }
        // GET: api/Colores
        [HttpGet]
        public IEnumerable<Colores> GetColores()
        {
            return this.context.Colores.ToList();
        }

        // GET: api/Colores/5
        [HttpGet("{id}", Name = "GetColor")]
        public IActionResult Get(int id)
        {
            var color = context.Colores.FirstOrDefault(color => color.Id == id);

            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        // POST: api/Colores
        [HttpPost]
        public IActionResult PostColores([FromBody] Colores color)
        {
            if (ModelState.IsValid) {
                context.Colores.Add(color);
                context.SaveChanges();
                return new CreatedAtRouteResult("GetColor", new {id = color.Id}, color);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Colores/5
        [HttpPut("{id}")]
        public IActionResult PutColores(int id, [FromBody] Colores color)
        {
            if (color.Id != id) 
            {
                return BadRequest();
            }
            context.Entry(color).State = EntityState.Modified;
            context.SaveChanges();
            return new CreatedAtRouteResult("GetColor", new {id = color.Id}, color);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteColores(int id)
        {
            var color = context.Colores.FirstOrDefault(color => color.Id == id);

            if (color == null)
            {
                return NotFound();
            }

            context.Colores.Remove(color);
            context.SaveChanges();
            return Ok(color);
        }
    }
}
