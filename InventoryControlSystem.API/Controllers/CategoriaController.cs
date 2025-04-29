using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoriaRequestDto>>> GetAllAsync()
        {
            try
            {
                var categorias = await _service.GetAllAsync();
                if (categorias == null || !categorias.Any())
                    return NotFound("Não foi encontrado categorias cadastradas");

                return Ok(categorias);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao buscar as categorias");
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<CategoriaRequestDto>> GetCategoriaByNome(string nome)
        {
            try
            {
                var categoria = await _service.GetCategoriaByNome(nome);
                if (categoria == null)
                    return NotFound("Categoria não encontrada");

                return Ok(categoria);
            }
            catch (KeyNotFoundException ex)
            {
                // Exceção mais específica
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao buscar a categoria");
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<CategoriaRequestDto>> CreateCategoria([FromBody] CategoriaRequestDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Dados inválidos");

                var categoria = await _service.CreateCategoriaAsync(dto);
                return CreatedAtAction(nameof(GetCategoriaByNome), new { nome = categoria.Nome }, categoria);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar a categoria");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaRequestDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Dados inválidos");

                var atualizado = await _service.UpdateCategoriaAsync(id, dto);
                if (!atualizado)
                    return NotFound($"Categoria com o ID '{id}' não foi encontrada.");

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a categoria");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                var removido = await _service.DeleteCategoriaAsync(id);
                if (!removido)
                    return NotFound($"Categoria com o ID '{id}' não foi encontrada.");

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao remover a categoria");
            }
        }
    }
}
