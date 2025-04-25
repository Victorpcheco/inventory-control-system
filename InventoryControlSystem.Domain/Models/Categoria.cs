using System.ComponentModel.DataAnnotations;

namespace InventoryControlSystem.Domain.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da categoria é obrigatório!")]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //public ICollection<Produto> Produtos { get; set; } // Relação de um para muitos
    }

}

