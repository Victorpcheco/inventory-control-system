using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Application.Services.Interfaces;
using InventoryControlSystem.Domain.Models;
using InventoryControlSystem.Domain.Repositories.Interfaces;

namespace InventoryControlSystem.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<FornecedorRequestDto>> GetAllFornecedoresAsync()
        {
            var fornecedores = await _repository.GetAllAsync();

            return fornecedores.Select(c => new FornecedorRequestDto
            {
                Nome = c.Nome,
                CpfCnpj = c.CpfCnpj,
                Telefone = c.Telefone,
                Email = c.Email,
                Endereco = c.Endereco

            }).ToList();
        }

        public async Task<FornecedorRequestDto> GetFornecedorByCpfCnpjAsync(string cpfCnpj)
        {
            var fornecedorExiste = await _repository.GetByCpfCnpjAsync(cpfCnpj);

            if (fornecedorExiste == null)
                throw new ArgumentException("Fornecedor não encontrado");

            return new FornecedorRequestDto
            {
                Nome = fornecedorExiste.Nome,
                CpfCnpj = fornecedorExiste.CpfCnpj,
                Telefone = fornecedorExiste.Telefone,
                Email = fornecedorExiste.Email,
                Endereco = fornecedorExiste.Endereco
            };
        }

        public async Task<FornecedorRequestDto> AddFornecedorAsync(FornecedorRequestDto fornecedorDto)
        {
            if (fornecedorDto == null)
                throw new ArgumentException("Dados inválidos");

            var fornecedorExiste = await _repository.GetByCpfCnpjAsync(fornecedorDto.CpfCnpj);

            if (fornecedorExiste != null)
                throw new ArgumentException("Fornecedor já está cadastrado no sistema!");

            var fornecedor = new Fornecedor(
                fornecedorDto.Nome,
                fornecedorDto.CpfCnpj,
                fornecedorDto.Email,
                fornecedorDto.Telefone
            );

            if (fornecedorDto.Endereco != null)
            {
                fornecedor.AtualizarEndereco(fornecedorDto.Endereco);
            }

            await _repository.AddAsync(fornecedor);

            return fornecedorDto;
        }

        public async Task<FornecedorRequestDto> UpdateFornecedorAsync(string cpfCnpj, FornecedorRequestDto fornecedorDto)
        {
            if (fornecedorDto == null)
                throw new ArgumentException("Dados inválidos");

            var fornecedorExiste = await _repository.GetByCpfCnpjAsync(cpfCnpj);

            if (fornecedorExiste == null)
                throw new ArgumentException("Fornecedor não encontrado");

            fornecedorExiste.AtualizarNome(fornecedorDto.Nome);
            fornecedorExiste.AtualizarTelefone(fornecedorDto.Telefone);
            fornecedorExiste.AtualizarEmail(fornecedorDto.Email);
            fornecedorExiste.AtualizarCpfCnpj(fornecedorDto.CpfCnpj);

            if (fornecedorDto.Endereco != null)
            {
                fornecedorExiste.AtualizarEndereco(fornecedorDto.Endereco);
            }

            await _repository.UpdateAsync(fornecedorExiste);

            return fornecedorDto;
        }

        public async Task<bool> DeleteFornecedorAsync(string cpfCnpj)
        {
            var fornecedor = await _repository.GetByCpfCnpjAsync(cpfCnpj);

            if (fornecedor == null)
                throw new ArgumentException("Fornecedor não encontrado");

            await _repository.DeleteAsync(fornecedor);
            return true;
        }
    }
}