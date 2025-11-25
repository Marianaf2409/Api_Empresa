using ApiEmpresa.Interfaces;
using ApiEmpresa.Models;
using Microsoft.AspNetCore.Mvc;
using ApiEmpresa.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync() =>
          Ok(await _clienteRepository.GetAllAsync());



        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetByIdAsync")]
        public  async Task<IActionResult> GetByIdAsync(int id)
        {
            var Cliente = await _clienteRepository.GetByIdAsync(id);
            if (Cliente == null) return NotFound();
            return Ok(Cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ClienteDto dto)
        {
            var Cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Whatsapp = dto.Whatsapp,
                Estado = dto.Estado,

            };
            var created = await _clienteRepository.AddAsync(Cliente);
            return CreatedAtRoute("GetByIdAsync", new { id = created.Id }, created);
        }
        

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody]ClienteDto dto)

        {
            var updateCliente = new Cliente
            {
                Nombre = dto.Nombre,
                Whatsapp = dto.Whatsapp,
                Estado = dto.Estado
            };
            var updated = _clienteRepository.UpdateAsync(id, updateCliente);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteAsync (int id)
        {
            var deleted = await _clienteRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
