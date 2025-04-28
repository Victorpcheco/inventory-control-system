using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlSystem.Application.DTOS
{
    public class ProdutoRequestDto
    {
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int QuantidadeEmEstoque { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        public int FornecedorId { get; set; }


    }
}
