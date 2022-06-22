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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var filme = await _filmeService.GetFilmeByIdAsync(id);
                if (filme == null) return NotFound("Filme por Id não encontrado.");

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Filme model)
        {
            try
            {
                var filme = await _filmeService.UpdateFime(id, model);
                if (filme == null) return BadRequest("Erro ao atualizar Filme.");

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _filmeService.DeleteFilme(id))
                    return Ok("Deletado");
                else
                    return BadRequest("Filme não encontrado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
    }
}
