using AnimalPaws.Data.Repositories;
using AnimalPaws.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalPawsAnnouncement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnunciosController : ControllerBase
    {
        private readonly IAnuncios _anuncios;

        public AnunciosController(IAnuncios anunciosRepository)
        {
            _anuncios = anunciosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnuncios()
        {
            return Ok(await _anuncios.GetAnuncios());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnuncio([FromBody] Anuncios anuncios)
        {
            if (anuncios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _anuncios.insertAnuncios(anuncios);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> updateAnuncios([FromBody] Anuncios anuncios)
        {
            if (anuncios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _anuncios.updateAnuncios(anuncios);
            return NoContent();
        }
        [HttpDelete("{id_anuncios}")]
        public async Task<IActionResult> DeleteAnuncios(int id_anuncios)
        {
            await _anuncios.DeleteAnuncios(new Anuncios() { id_anuncios = id_anuncios });

            return NoContent();
        }
    }
}
