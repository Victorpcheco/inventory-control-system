using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ProdutoRequestDto>> GetAllProdutosAsync()
    {
        var produtos = await _repository.GetAllAsync();

        return produtos.Select(p => new ProdutoRequestDto
        {
            Nome = p.Nome,
            Descricao = p.Descricao,
            QuantidadeEmEstoque = p.QuantidadeEmEstoque,
            Preco = p.Preco,
            CategoriaId = p.CategoriaId,
            FornecedorId = p.FornecedorId
        }).ToList();
    }

    public async Task<ProdutoRequestDto> GetProdutoByIdAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
            throw new ArgumentException("Produto não encontrado");

        return new ProdutoRequestDto
        {
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
            Preco = produto.Preco,
            CategoriaId = produto.CategoriaId,
            FornecedorId = produto.FornecedorId
        };
    }

    public async Task<ProdutoRequestDto> AddProdutoAsync(ProdutoRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentException("Dados inválidos");

        var produto = new Produto(
            dto.Nome,
            dto.Descricao,
            dto.QuantidadeEmEstoque,
            dto.Preco,
            dto.CategoriaId,
            dto.FornecedorId
        );

        await _repository.AddAsync(produto);

        return dto;
    }

    public async Task<ProdutoRequestDto> UpdateProdutoAsync(int id, ProdutoRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentException("Dados inválidos");

        var produtoExistente = await _repository.GetByIdAsync(id);

        if (produtoExistente == null)
            throw new ArgumentException("Produto não encontrado");

        produtoExistente.AtualizarNome(dto.Nome);
        produtoExistente.AtualizarDescricao(dto.Descricao);
        produtoExistente.AtualizarEstoque(dto.QuantidadeEmEstoque);
        produtoExistente.AtualizarPreco(dto.Preco);
        produtoExistente.AtualizarCategoria(dto.CategoriaId);
        produtoExistente.AtualizarFornecedor(dto.FornecedorId);

        await _repository.UpdateAsync(produtoExistente);

        return dto;
    }

    public async Task<bool> DeleteProdutoAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
            throw new ArgumentException("Produto não encontrado");

        await _repository.DeleteAsync(produto);
        return true;
    }
}
