using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InventoryControlSystem.Application.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<Categoria> GetCategoriaByNome(string nome)
        {
            var categoria = await _repository.GetCategoriaByNome(nome);

            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");

            return await _repository.GetCategoriaByNome(nome);
        }

        public async Task<CategoriaRequestDto> CreateCategoriaAsync(CategoriaRequestDto dto)
        {

            var categoria = await _repository.GetCategoriaByNome(dto.Nome);

            if (categoria != null)
                throw new ArgumentException("Categoria já cadastrada");

            categoria = new Categoria()
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
                throw new ArgumentException("Categoria não encontrada");

            categoria.Nome = dto.Nome;
            categoria.Descricao = dto.Descricao;

            await _repository.UpdateAsync(categoria);

            return true;
        }

        public async Task<bool> DeleteCategoriaAsync(int id) 
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
                throw new ArgumentException("Categoria não cadastrada");

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
