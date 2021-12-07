using AnimalPaws.Data.Repositories;
using AnimalPaws.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalPawsAnnouncement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuarios;

        public UsuariosController(IUsuarios usuariosRepository)
        {
            _usuarios = usuariosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getUsuarios()
        {
            return Ok(await _usuarios.GetUsuarios());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuarios usuarios)
        {
            if (usuarios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarios.insertUsuarios(usuarios);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> updateUsuarios([FromBody] Usuarios usuarios)
        {
            if (usuarios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarios.updateUsuarios(usuarios);
            return NoContent();
        }
        [HttpDelete("{id_usuarios}")]
        public async Task<IActionResult> DeleteUsuarios(int id_usuarios)
        {
            await _usuarios.deleteUsuarios(new Usuarios() { id_usuarios = id_usuarios });

            return NoContent();
        }
    }
}

