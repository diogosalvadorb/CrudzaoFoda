using CrudzaoFoda.Application.Contratos;
using CrudzaoFoda.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CrudzaoFoda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : Controller
    {   
        private readonly IFilmeService _filmeService;
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var filme = await _filmeService.GetAllFilmesAsync();
                if (filme == null) return NotFound("Nenhum Filme encontrado.");

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Filme model)
        {
            try
            {
                var filme = await _filmeService.AddFilme(model);
                if (filme == null) return BadRequest("Erro ao adicionar Filme");

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
    }
}
