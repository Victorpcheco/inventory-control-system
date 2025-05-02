using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;

namespace InventoryControlSystem.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        // Alterado para retornar IReadOnlyList para garantir imutabilidade da coleção.
        public async Task<IReadOnlyList<CategoriaRequestDto>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            // Mapeia entidades para DTOs para não expor o domínio.
            return categorias.Select(c => new CategoriaRequestDto
            {
                Nome = c.Nome,
                Descricao = c.Descricao
            }).ToList();
        }

        // Retorna DTO e evita chamada duplicada ao repositório.
        public async Task<CategoriaRequestDto> GetCategoriaByNome(string nome)
        {
            var categoria = await _repository.GetByNomeAsync(nome);

            if (categoria == null)
                throw new KeyNotFoundException("Categoria não encontrada");

            return new CategoriaRequestDto
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };
        }

        public async Task<CategoriaRequestDto> CreateCategoriaAsync(CategoriaRequestDto dto)
        {
            var categoria = await _repository.GetByNomeAsync(dto.Nome);

            if (categoria != null)
                throw new ArgumentException("Categoria já cadastrada");

            categoria = new Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            await _repository.AddAsync(categoria);

            return new CategoriaRequestDto
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };
        }

        public async Task<bool> UpdateCategoriaAsync(int id, CategoriaRequestDto dto)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null)
                throw new KeyNotFoundException("Categoria não encontrada");

            categoria.Nome = dto.Nome;
            categoria.Descricao = dto.Descricao;

            await _repository.UpdateAsync(categoria);

            return true;
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
                throw new KeyNotFoundException("Categoria não cadastrada");

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
