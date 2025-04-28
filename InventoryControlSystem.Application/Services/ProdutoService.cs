using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;

namespace InventoryControlSystem.Application.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository repository)
        {
            _produtoRepository = repository;    
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id do produto não pode ser menor ou igual a 0!");
            if (id == null)
                throw new ArgumentNullException("O id do produto não pode ser nulo!");

            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<Produto> AddProdutoAsync(ProdutoRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("O produto não pode ser nulo!");

            var produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                QuantidadeEmEstoque = dto.QuantidadeEmEstoque,
                Preco = dto.Preco,
                CategoriaId = dto.CategoriaId,
                FornecedorId = dto.FornecedorId,
                DataCadastroProduto = DateTime.UtcNow
            };

            await _produtoRepository.AddAsync(produto);
            return produto;
        }

        public async Task UpdateProdutoAsync(int id, ProdutoRequestDto dto)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);

            if (produtoExistente == null)
                throw new KeyNotFoundException("Produto não encontrado!");

            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "O produto não pode ser nulo!");

            produtoExistente.Nome = dto.Nome ?? produtoExistente.Nome;
            produtoExistente.Descricao = dto.Descricao ?? produtoExistente.Descricao;
            produtoExistente.QuantidadeEmEstoque = dto.QuantidadeEmEstoque > 0 ? dto.QuantidadeEmEstoque : produtoExistente.QuantidadeEmEstoque;
            produtoExistente.Preco = dto.Preco > 0 ? dto.Preco : produtoExistente.Preco;
            produtoExistente.CategoriaId = dto.CategoriaId > 0 ? dto.CategoriaId : produtoExistente.CategoriaId;
            produtoExistente.FornecedorId = dto.FornecedorId > 0 ? dto.FornecedorId : produtoExistente.FornecedorId;

            await _produtoRepository.UpdateAsync(produtoExistente);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null)
                throw new KeyNotFoundException("Produto não encontrado!");
            await _produtoRepository.DeleteAsync(produtoExistente);
        }






    }
}
