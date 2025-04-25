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









    }
}
