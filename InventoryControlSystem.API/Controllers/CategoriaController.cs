using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAllAsync()
        {
            try
            {
                var categorias = await _service.GetAllAsync();

                if (categorias == null || !categorias.Any())
                {
                    return NotFound("Não foi encontrado categorias cadastradas");
                }

                return Ok(categorias);
            }
            catch
            {
                return BadRequest("Ocorreu um erro ao buscar as categorias");
            }
        }


        [HttpGet("{nome}")]
        public async Task<ActionResult<Categoria>> GetCategoriaByNome(string nome)
        {
            try
            {
                var categoria = await _service.GetCategoriaByNome(nome);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada");
                }
                return Ok(categoria);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao buscar a categoria");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaRequestDto>> CreateCategoria([FromBody] CategoriaRequestDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Dados inválidos");
                }
                var categoria = await _service.CreateCategoriaAsync(dto);
                return CreatedAtAction(nameof(GetCategoriaByNome), new { nome = categoria.Nome }, categoria);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao criar a categoria");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaRequestDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Dados inválidos");
                }
                var atualizado = await _service.UpdateCategoriaAsync(id, dto); 

                if (!atualizado)
                {
                    return NotFound($"Categoria com o ID '{id}' não foi encontrada.");
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a categoria");
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria (int id)
        {
            try
            {
                
                    if (id == null)
                    {
                        return BadRequest("Dados inválidos");
                    }
                    var categoria = await _service.DeleteCategoriaAsync(id);
                    return Ok (categoria);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao criar a categoria");
            }

        }
    }
}
