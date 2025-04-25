namespace InventoryControlSystem.Domain.Models
{
    public class Categoria
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //public ICollection<Produto> Produtos { get; set; } // Relação de um para muitos


        public Categoria(string nome)
        {
            
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo nome não pode ser nulo ou vazio!");

            Nome = nome;

        }
    }

}

