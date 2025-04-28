using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {


        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var produtos = await _service.GetProdutosAsync();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _service.GetByIdAsync(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduto([FromBody] ProdutoRequestDto dto)
        {
            try
    {
        if (dto == null)
        {
            return BadRequest("Dados inválidos");
        }

        var produto = await _service.AddProdutoAsync(dto);

        // Mapeia o Produto para ProdutoRequestDto (se necessário)
        var produtoDto = new ProdutoRequestDto
        {
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
            Preco = produto.Preco,
            CategoriaId = produto.CategoriaId,
            FornecedorId = produto.FornecedorId
        };

        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produtoDto);
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
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProdutoRequestDto dto)
        {
            try
            {
                await _service.UpdateProdutoAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _service.DeleteProdutoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
