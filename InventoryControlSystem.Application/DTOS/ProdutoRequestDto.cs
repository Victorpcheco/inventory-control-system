using System.ComponentModel.DataAnnotations;

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
