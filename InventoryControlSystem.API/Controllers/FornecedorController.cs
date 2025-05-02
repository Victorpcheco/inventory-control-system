using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<FornecedorRequestDto>>> GetAllFornecedoresAsync()
        {
            try
            {
                var fornecedores = await _service.GetAllFornecedoresAsync();
                if (fornecedores == null || !fornecedores.Any())
                    return NotFound("Não foi encontrado fornecedores cadastrados");

                return Ok(fornecedores);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os fornecedores");
            }
        }

        [HttpGet("{cpfCnpj}")]
        [Authorize]
        public async Task<ActionResult<FornecedorRequestDto>> GetFornecedorcpfCnpj(string cpfCnpj)
        {
            try
            {
                var fornecedor = await _service.GetFornecedorByCpfCnpjAsync(cpfCnpj);
                if (fornecedor == null)
                    return NotFound("Fornecedor não encontrado");
                return Ok(fornecedor);
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
                return StatusCode(500, "Ocorreu um erro ao buscar o fornecedor");
            }
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<FornecedorRequestDto>> CreateFornecedor([FromBody] FornecedorRequestDto fornecedorDto)
        {
            try
            {
                if (fornecedorDto == null)
                    return BadRequest("Dados inválidos");

                var categoria = await _service.AddFornecedorAsync(fornecedorDto);
                return CreatedAtAction(nameof(GetFornecedorcpfCnpj), new { cpfCnpj = categoria.CpfCnpj }, categoria);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar um novo fornecedor");
            }
        }

        [HttpPut("update/{cpfCnpj}")]
        [Authorize]
        public async Task<ActionResult> UpdateFornecedor(string cpfCnpj, [FromBody] FornecedorRequestDto fornecedordto)
        {
            try
            {
                if (fornecedordto == null)
                    return BadRequest("Dados inválidos");

                var fornecedorAtualizado = await _service.UpdateFornecedorAsync(cpfCnpj, fornecedordto);
                if (fornecedorAtualizado == null) // Fix: Check for null instead of using '!'
                    return NotFound($"Categoria com o ID '{cpfCnpj}' não foi encontrada.");

                return NoContent();
            }
            catch (KeyNotFoundException ex) // quando o CPF/CNPJ fornecido não corresponde a nenhum fornecedor existente no banco de dados.
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex) // é lançada quando um argumento passado para um método é inválido ou não atende aos requisitos esperados.
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a categoria"); // generico
            }
        }

        [HttpDelete("delete/{cpfCnpj}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFornecedor(string cpfCnpj)
        {

            try
            {
                var fornecedorRemovido = await _service.DeleteFornecedorAsync(cpfCnpj);
                if (!fornecedorRemovido)
                    return NotFound($"Categoria com o ID '{cpfCnpj}' não foi encontrada.");

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
                return StatusCode(500, "Ocorreu um erro ao remover o fornecedor");
            }
        }
    }
}