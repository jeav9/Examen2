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
    public class CiudadController : ControllerBase
    {
        private readonly CiudadManager _ciudadManager;
        public CiudadController(CiudadManager ciudadManager)
        {
            _ciudadManager = ciudadManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _ciudadManager.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _ciudadManager.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ciudad ciudad)
        {
            var result = await _ciudadManager.Create(ciudad);

            if (result != null) return BadRequest(result);

            return CreatedAtAction(nameof(Get), new { id = ciudad.Id }, ciudad);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ciudad ciudad)
        {
            var result = await _ciudadManager.Update(ciudad);

            if (result != null) return BadRequest(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _ciudadManager.Delete(id);

            if (result != null) return BadRequest(result);

            return NoContent();
        }
    }
}
