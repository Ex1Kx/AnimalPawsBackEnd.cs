using AnimalPaws.Data.Repositories;
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
    }
}
