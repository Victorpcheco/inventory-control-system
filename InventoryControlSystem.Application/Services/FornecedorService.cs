using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Fornecedor> AddFornecedorAsync(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                throw new ArgumentNullException("Dados inválidos");
            }

            var fornecedorExiste = await _repository.GetByCpfCnpj(fornecedor.CpfCnpj);

            if (fornecedorExiste == null)
            {
                await _repository.AddAsync(fornecedor);
                return (fornecedor);
            }
            else
            {
                throw new ArgumentNullException("Fornecedor já está cadastrado no sistema!");
            }
        }

        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync()
        {
            var fornecedores = await _repository.GetAllAsync();

            if (fornecedores == null)
            {
                throw new ArgumentNullException("Nenhum fornecedor encontrado");
            }

            return (fornecedores);
        }
    }
}
