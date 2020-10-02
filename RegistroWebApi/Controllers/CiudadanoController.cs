using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroWebApi.Core.DomainManager;
using RegistroWebApi.Models;

namespace RegistroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanoController : ControllerBase
    {
        private readonly CiudadanoManager _ciudadanoManager;
        public CiudadanoController(CiudadanoManager ciudadanoManager)
        {
            _ciudadanoManager = ciudadanoManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _ciudadanoManager.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _ciudadanoManager.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ciudadano ciudadano)
        {
            var result = await _ciudadanoManager.Create(ciudadano);

            if (result != null) return BadRequest(result);

            return CreatedAtAction(nameof(Get), new { id = ciudadano.Id }, ciudadano);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ciudadano ciudadano)
        {
            var result = await _ciudadanoManager.Update(ciudadano);

            if (result != null) return BadRequest(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _ciudadanoManager.Delete(id);

            if (result != null) return BadRequest(result);

            return NoContent();
        }
    }
}
