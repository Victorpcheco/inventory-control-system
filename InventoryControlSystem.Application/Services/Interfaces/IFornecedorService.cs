using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControlSystem.Application.DTOS;
using InventoryControlSystem.Domain.Models;

namespace InventoryControlSystem.Application.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IReadOnlyList<FornecedorRequestDto>> GetAllFornecedoresAsync();
        Task<FornecedorRequestDto> GetFornecedorByCpfCnpjAsync(string cpfCnpj);
        Task<FornecedorRequestDto> AddFornecedorAsync(FornecedorRequestDto dto);
        Task<FornecedorRequestDto> UpdateFornecedorAsync(string cpfCnpj, FornecedorRequestDto fornecedorDto);
        Task<bool> DeleteFornecedorAsync(string cpfCnpj);

    }
}
