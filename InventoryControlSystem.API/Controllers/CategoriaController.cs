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
    }
}
