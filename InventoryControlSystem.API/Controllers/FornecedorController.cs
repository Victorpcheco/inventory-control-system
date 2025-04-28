using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {

        private readonly IFornecedorService _service;

        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> CreateFornecedor([FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _service.AddFornecedorAsync(fornecedor);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetAllFornecedores()
        {
            try
            {
                var fornecedores = await _service.GetAllFornecedoresAsync();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cpfCnpj}")]
        public async Task<IActionResult> UpdateFornecedor(string cpfCnpj, [FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.UpdateFornecedorAsync(cpfCnpj, fornecedor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}