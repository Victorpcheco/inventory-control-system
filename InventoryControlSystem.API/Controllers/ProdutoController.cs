using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProdutoRequestDto>>> GetAllProdutosAsync()
        {
            try
            {
                var produtos = await _service.GetAllProdutosAsync();
                if (produtos == null || !produtos.Any())
                    return NotFound("Não foram encontrados produtos cadastrados");

                return Ok(produtos);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os produtos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoRequestDto>> GetProdutoById(int id)
        {
            try
            {
                var produto = await _service.GetProdutoByIdAsync(id);
                if (produto == null)
                    return NotFound("Produto não encontrado");
                return Ok(produto);
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
                return StatusCode(500, "Ocorreu um erro ao buscar o produto");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProdutoRequestDto>> CreateProduto([FromBody] ProdutoRequestDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    return BadRequest("Dados inválidos");

                var produto = await _service.AddProdutoAsync(produtoDto);
                return Ok(produtoDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar um novo produto");
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateProduto(int id, [FromBody] ProdutoRequestDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    return BadRequest("Dados inválidos");

                await _service.UpdateProdutoAsync(id, produtoDto);
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
                return StatusCode(500, "Ocorreu um erro ao atualizar o produto");
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _service.DeleteProdutoAsync(id);
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
                return StatusCode(500, "Ocorreu um erro ao remover o produto");
            }
        }
    }
}
